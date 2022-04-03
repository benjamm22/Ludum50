using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    public Score score;
    public EnemySpawner spawner;
    public float moveSpeed = 3.0f;
    public float strafeSpeed = 2.0f;
    public Rigidbody rb;
    float horInput;
    float increaseCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(score.score / spawner.limit > increaseCounter)
        {
            increaseCounter++;
            moveSpeed += 1;
            strafeSpeed += 1;
        }

        Vector3 forwardMovement = transform.up * moveSpeed * Time.fixedDeltaTime * -1; // transform.up IS transform.forward for this man
        
        Vector3 horizontalMovement = transform.right * horInput * strafeSpeed * Time.fixedDeltaTime;

        if(transform.position.x + horizontalMovement.x < -5 || transform.position.x + horizontalMovement.x > 5)
        {
            horizontalMovement.x *= 0;
        }

        rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxis("Horizontal");
    }

}
