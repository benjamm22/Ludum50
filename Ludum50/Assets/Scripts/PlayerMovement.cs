using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform playerTransform;

    bool useSnapback = false;
    KeyCode key;
    KeyCode previousKey;
    float snapbackTime;

    float forwardMovement = 10f;

    float timeElapsed = 0;
    float lerpDuration = .4f;
    float startValue = 0;
    const float endAmount = 5;
    float endValue = endAmount;
    float valueToLerp;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = this.transform;
        snapbackTime = Time.time;
        //Debug.Log(Time.time);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (Event.current.isKey && Event.current.type == EventType.KeyDown)
        {
            key = Event.current.keyCode;
        }
    }

    // FixedUpdate is the preferred way to make physics changes
    void FixedUpdate()
    {
        HandleSideToSide();
        CheckSnapback();
        MoveForward();
    }

    private void MoveForward()
    {
        playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z + (forwardMovement * Time.deltaTime));
    }

    private void NewHandleMovement()
    {
        float endWithDirection = 0;
        int direction = 0;        
        if (key == KeyCode.LeftArrow)
        {
            direction = -1;
        }
        else if (key == KeyCode.RightArrow)
        {
            direction = 1;
        }

        if (key != KeyCode.None && timeElapsed < lerpDuration)
        {
            // movement key pressed and havent finished the lerp movement yet

            float t = timeElapsed / lerpDuration;
            //t = t * t * (3f - 2f * t);
            valueToLerp = Mathf.Lerp(startValue, endWithDirection, t);
            playerTransform.position = new Vector3(valueToLerp, 0, playerTransform.position.z);
            timeElapsed += Time.deltaTime;
            AddSnapbackTime();
        }
    }

    private void HandleSideToSide()
    {
        if (timeElapsed == 0)
        {
            startValue = playerTransform.position.x;
        }

        float endWithDirection = endValue;
        if (key == KeyCode.LeftArrow)
        {
            endWithDirection *= -1;
        }
        else if (key != KeyCode.RightArrow)
        {
            key = KeyCode.None;
            endWithDirection = startValue;
        }
        if (startValue == 0 || startValue % endAmount == 0)
        {
            // change from an ammount to a location
            // but only if we arent already in movement
            endWithDirection = startValue + endWithDirection;
        }

        if (previousKey != KeyCode.None && key != KeyCode.None && previousKey != key)
        {
            // pressed a key to go back before the got to final location
            MoveBack(out endWithDirection);
        }
        previousKey = key;

        if (key != KeyCode.None && timeElapsed < lerpDuration)
        {
            // movement key pressed and havent finished the lerp movement yet

            float t = timeElapsed / lerpDuration;
            //t = t * t * (3f - 2f * t);
            valueToLerp = Mathf.Lerp(startValue, endWithDirection, t);
            playerTransform.position = new Vector3(valueToLerp, 0, playerTransform.position.z);
            timeElapsed += Time.deltaTime;
            AddSnapbackTime();
        }
        else if (key != KeyCode.None)
        {
            // finish movement by setting final position
            playerTransform.position = new Vector3(endWithDirection, 0, transform.position.z);
            key = KeyCode.None;
        }
        else
        {
            // reset values
            endValue = endAmount;
            timeElapsed = 0;
            key = KeyCode.None;
        }
    }

    private void MoveBack(out float endWithDirection)
    {
        endWithDirection = startValue;
        endValue = startValue;
        startValue = playerTransform.position.x;
        timeElapsed = lerpDuration - timeElapsed;
    }

    private void AddSnapbackTime()
    {
        if (snapbackTime < Time.time)
        {
            snapbackTime = Time.time + .5f;
        }
        else
        {
            snapbackTime = Time.time + lerpDuration;
        }
    }

    // if the player isnt in the middle and its time to put them back in the middle, set their position - this only accounts for horizontal movement
    // also this is does not lerp
    private void CheckSnapback()
    {
        if (useSnapback && playerTransform.position.x != 0 && Time.time > snapbackTime)
        {
            playerTransform.position = new Vector3(0, 0, playerTransform.position.z);
        }
    }
}
