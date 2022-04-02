using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    private Vector3 positionDelta = new Vector3(0, 3, -10);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // lerp this so its smoother
        this.transform.position = Player.transform.position + positionDelta;
    }
}
