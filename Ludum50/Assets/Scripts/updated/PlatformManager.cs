using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platforms;
    [SerializeField]
    private float zOffset = 0;
    public float zAmount = 49;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(platforms[0], new Vector3(0, -.5f, zAmount * 0), Quaternion.Euler(0, 0, 0));
        //zOffset += zAmount;

        for (int i = 0; i < platforms.Length; i++)
        {
            Instantiate(platforms[i], new Vector3(0, -.5f, zAmount * (i)), Quaternion.Euler(0, 0, 0));
            zOffset += zAmount;
        }
    }

    public void ReusePlatform(GameObject platform)
    {
        platform.transform.position = new Vector3(0, -.5f, zOffset);
        zOffset += zAmount;        
    }
}
