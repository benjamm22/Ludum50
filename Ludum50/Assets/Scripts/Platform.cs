using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformManager platformManager;

    private void OnEnable()
    {
        platformManager = GameObject.FindObjectOfType<PlatformManager>();
        Debug.Log("Found Manager");
    }

    private void OnBecameInvisible()
    {
        platformManager.ReusePlatform(this.gameObject);
    }
}