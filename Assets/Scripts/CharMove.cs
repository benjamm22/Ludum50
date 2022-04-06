using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    //public Score score;
    public float moveSpeed = 3.0f;
    public float strafeSpeed = 2.0f;
    public Rigidbody rb;
    float horInput;
    float increaseCounter = 1;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(Score.score / 10 > increaseCounter)
        {
            increaseCounter++;
            moveSpeed += .5f;
            strafeSpeed += .33f;
        }

        Vector3 forwardMovement = transform.up * moveSpeed * Time.fixedDeltaTime * -1; // transform.up IS transform.forward for this man
        
        Vector3 horizontalMovement = transform.right * horInput * strafeSpeed * Time.fixedDeltaTime;

        if(transform.position.x + horizontalMovement.x < -4 || transform.position.x + horizontalMovement.x > 4)
        {
            horizontalMovement.x *= 0;
        }

        rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", moveSpeed / 3.5f);
    }

}
