using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemySpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject objectToSpawn;
    public GameObject parent;
    public int numberToSpawn = 1;
    public int limit = 10;
    public float InitialSpawnRate = 1;
    public float FinalSpawnRate = .1f;
    public float SpawnDistance = 10;
    public float DeathTimer = 3;
    public float CurrentRate;

    float rate;
    int amountSpawned = 0;
    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        rate = InitialSpawnRate;
        spawnTimer = rate;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentRate = rate;
        if (parent.transform.childCount < limit)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    GameObject newObject = Instantiate(
                        objectToSpawn,
                        new Vector3(GetXLocation(), 0, player.transform.position.z + SpawnDistance),
                        Quaternion.identity,
                        parent.transform);
                    amountSpawned++;

                    if (amountSpawned % limit == 0)
                    {
                        rate -= .1f;
                    }
                    Destroy(newObject, DeathTimer);
                }
                spawnTimer = rate;
            }
        }
        if (rate < FinalSpawnRate)
        {
            rate = FinalSpawnRate;
        }
    }

    float GetXLocation()
    {
        float modifier = Random.Range(0.0f, 10.0f);
        if (modifier > 5)
        {
            return modifier * -1 + 5;
        }
        return modifier;
    }
}
