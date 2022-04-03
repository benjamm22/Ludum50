using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformManager platformManager;

    private void OnEnable()
    {
        platformManager = GameObject.FindObjectOfType<PlatformManager>();
    }

    private void OnBecameInvisible()
    {
        platformManager.ReusePlatform(this.gameObject);
    }
}
