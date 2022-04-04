using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Score score;
    public GameObject player;
    public GameObject[] objectToSpawn;
    public GameObject parent;

    public int limit = 1000;
    public float spawnDistance = 150;
    public float delay;
    public float runtime;
    public float timeSince;
    public float initialDelay = .33f;
    public float finalDelay = .01f;
    public float rampDuration = 10000f;
    public float amountSpawned;
    public float maxDelay;

    // Start is called before the first frame update
    void Start()
    {
        runtime = timeSince = 0.0f;
        delay = initialDelay;
    }

    // Update is called once per frame
    void Update()
    {
        runtime += Time.deltaTime;
        timeSince += Time.deltaTime;
        delay -= Mathf.Lerp(initialDelay, finalDelay, timeSince / rampDuration);

        if (amountSpawned == 0)
        {
            for (int i = 15; i < spawnDistance; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    customSpawn(i);
                }

                i += 10;

            }
        }
        
        if (timeSince > delay)
        {
            customSpawn(spawnDistance);
        }

        if (delay <= maxDelay)
        {
            delay = maxDelay;
        }


        Debug.Log("Delay = " + delay);
    }

    void customSpawn(float spawnDist)
    {
        timeSince = 0.0f;
        int enemyIndex = UnityEngine.Random.Range(0, objectToSpawn.Length);
        Instantiate(objectToSpawn[enemyIndex], new Vector3(GetXLocation(), 0, player.transform.position.z + spawnDist),
                        Quaternion.identity,
                        parent.transform);
        amountSpawned++;

    }

    float GetXLocation()
    {
        float modifier = Random.Range(0f, 8f);
        if (modifier > 4)
        {
            return modifier * -1 + 4;
        }
        return modifier;
    }
}