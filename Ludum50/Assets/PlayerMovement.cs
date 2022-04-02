using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform;
    public KeyCode key;
    public float snapbackTime;

    // Start is called before the first frame update
    void Start()
    {
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
            //Debug.Log(key);
        }
    }

    // FixedUpdate is the preferred way to make physics changes
    void FixedUpdate()
    {
        float horizontal = 0;
        float forward = .2f;

        if (key == KeyCode.LeftArrow)
        {
            horizontal = -5;
        }
        else if (key == KeyCode.RightArrow)
        {
            horizontal = 5;
        }

        // lerp this so its smoother
        // if the player isnt in the middle and its time to put them back in the middle, set their position
        if (playerTransform.position.x != 0 && Time.time > snapbackTime)
        {
            playerTransform.position = new Vector3(0, 0, playerTransform.position.z);
        }
        else if (horizontal != 0) // only move if a key was pressed
        {
            playerTransform.position += new Vector3(horizontal, 0, 0);
            key = KeyCode.None;

            // check time so it cant be exteded by more movement
            if (snapbackTime < Time.time)
            {
                snapbackTime = Time.time + .5f;
            }

            // reset the keypress
            key = KeyCode.None;            
        }
        playerTransform.position += new Vector3(0, 0, forward);
    }
}
