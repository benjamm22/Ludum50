using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{

    public float moveSpeed = 3.0f;
    public float strafeSpeed = 2.0f;
    public Rigidbody rb;
    float horInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 forwardMovement = transform.up * moveSpeed * Time.fixedDeltaTime * -1; // transform.up IS transform.forward for this man
        Vector3 horizontalMovement = transform.right * horInput * strafeSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxis("Horizontal");
    }

}
