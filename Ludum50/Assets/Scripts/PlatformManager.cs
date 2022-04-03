using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platforms;
    [SerializeField]
    private int zOffset = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < platforms.Length; i++)
        {
            Instantiate(platforms[i], new Vector3(0, -1, 12 * i), Quaternion.Euler(0, 0, 0));
            zOffset += 12;
        }
    }

    public void ReusePlatform(GameObject platform)
    {
        platform.transform.position = new Vector3(0, -1, zOffset);
        Debug.Log("Reuse: " + zOffset);
        zOffset += 12;
        
    }
}
