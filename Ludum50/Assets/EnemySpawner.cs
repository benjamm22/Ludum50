using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject objectToSpawn;
    public GameObject parent;
    public int numberToSpawn = 1;
    public int limit = 10;
    public float InitialSpawnRate = 1;
    public float FinalSpawnRate = .1f;    
    public float SpawnDistance = 10;
    public float DeathTimer = 2;
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
        if(rate < FinalSpawnRate)
        {
            rate = FinalSpawnRate;
        }
    }

    float GetXLocation()
    {
        float modifier = Random.Range(0, 3);
        if(modifier == 0)
        {
            return -5;
        }
        else if(modifier == 1)
        {
            return 0;
        }
        else
        {
            return 5;
        }
    }
}