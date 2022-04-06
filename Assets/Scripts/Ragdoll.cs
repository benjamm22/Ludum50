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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            RagdollOn();

            Invoke("DelayedScene", 4.0f);            
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
            rb.AddExplosionForce(80f, transform.position, 5f, 40f, ForceMode.Impulse);
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

    void DelayedScene()
    {
        SceneManager.LoadScene("Game Over");
    }

}
