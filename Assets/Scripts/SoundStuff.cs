using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStuff : MonoBehaviour
{

    public AudioSource audioSource;
    public float pitchIncrease;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.pitch += pitchIncrease * Time.deltaTime;
    }
}
