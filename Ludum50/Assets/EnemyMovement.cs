using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    private float timeOfLastJump;
    private float jumpCooldown = 3;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + new Vector3(0, 0, 15);
        timeOfLastJump = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeOfLastJump + jumpCooldown)
        {
            transform.position = player.transform.position + new Vector3(0, 0, 5);
            timeOfLastJump = Time.time;
        }
    }
}
