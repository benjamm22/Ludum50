using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{

    public GameObject enemy;
    //public Score score;

    private void OnBecameInvisible()
    {
        Destroy(enemy);
        Score.score += 1;
    }
}

