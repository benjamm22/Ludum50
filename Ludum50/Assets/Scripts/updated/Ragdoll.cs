using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{


    public CapsuleCollider mainCol;
    public GameObject thisRig;
    public Animator thisAnim;


    Collider[] ragdollColliders;
    Rigidbody[] rigidBodies;

    void Start()
    {
        GetRagdollParts();
        RagdollOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        { 
            RagdollOn();

            Invoke("DelayedScene", 4.0f);

            
            /*
            foreach (Rigidbody rb in rigidBodies)
            {
                rb.AddExplosionForce(5f, transform.position, 5f, 1000f, ForceMode.Impulse);
            }
            */
        }
         
      
    }

    void GetRagdollParts()
    {
        ragdollColliders = thisRig.GetComponentsInChildren<Collider>();
        rigidBodies = thisRig.GetComponentsInChildren<Rigidbody>();
    }

    void RagdollOn()
    {
        thisAnim.enabled = false;

        foreach (Collider col in ragdollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rb in rigidBodies)
        {
            rb.isKinematic = false;
            SetVelocity(rb);
        }

        
        mainCol.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CharMove>().enabled = false;
    }

    void RagdollOff()
    {
        foreach(Collider col in ragdollColliders)
        {
            col.enabled = false;
        }

        foreach (Rigidbody rb in rigidBodies)
        {
            rb.isKinematic = true;
        }

        thisAnim.enabled = true;
        mainCol.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<CharMove>().enabled = true;
    }



    void SetVelocity(Rigidbody rig)
    {
        Vector3 Vrig = rig.velocity;
        //Modify each axis
        Vrig.x = 0f;
        Vrig.y = 7f;
        Vrig.z = 1f;
        rig.velocity = Vrig;
    }


    void DelayedScene()
    {
        SceneManager.LoadScene("Game Over");
    }

}
