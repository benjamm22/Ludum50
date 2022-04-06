using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 1;

    private void Update()
    {
        Debug.Log(score);
    }
}

