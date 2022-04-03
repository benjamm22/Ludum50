using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Score score;
    public GameObject player;
    public GameObject objectToSpawn;
    public GameObject parent;
    public int numberToSpawn = 1;
    public int limit = 50;
    public float InitialSpawnRate = 1;
    public float FinalSpawnRate = .1f;    
    public float SpawnDistance = 10;
    public float DeathTimer = 4;
    public float CurrentRate;
    int increaseCounter = 1;
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
        if (score.score / limit > increaseCounter)
        {
            increaseCounter++;
            numberToSpawn++;
            limit *= 2;
            rate -= .05f;
        }

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
                    score.score++;

                    Destroy(newObject, DeathTimer);
                }
                spawnTimer = rate;
            }
        }
        if(rate < FinalSpawnRate)
        {
            rate = FinalSpawnRate;
        }
        if(numberToSpawn > 5)
        {
            numberToSpawn = 5;
        }
    }

    float GetXLocation()
    {
        float modifier = Random.Range(0f, 10f);
        if(modifier > 5)
        {
            return modifier * -1 + 5;
        }
        return modifier;
    }
}