using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    private float timeOfLastJump;
    public float JumpDistance = 10;
    public float RepositionInFrontTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = player.transform.position + new Vector3(0, 0, 15);
        timeOfLastJump = Time.time;
        Destroy(this, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeOfLastJump + RepositionInFrontTimer)
        {
            transform.position = player.transform.position + new Vector3(GetModifier(), 0, JumpDistance);
            timeOfLastJump = Time.time;
        }
    }

    float GetModifier()
    {
        float modifier = Random.Range(0, 3);
        if (modifier == 0)
        {
            return -5;
        }
        else if (modifier == 1)
        {
            return 0;
        }
        else
        {
            return 5;
        }
    }
}
