using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;

    public GameObject bahserPrefab;

    public float spawnInterwal = 1;

    float timeSinceSpawn;

    float spawnDistance = 20;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        timeSinceSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn > spawnInterwal)
        {
           // Vector3 randomPosition = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));

            Vector2 random = Random.insideUnitCircle.normalized;

            Vector3 randomPosition = new Vector3(random.x, 0, random.y);


            randomPosition *= spawnDistance;

            randomPosition += player.position;

            if (!Physics.CheckSphere(new Vector3(randomPosition.x, 1, randomPosition.z), 0.5f))
            {

                Instantiate(bahserPrefab, randomPosition, Quaternion.identity);

                timeSinceSpawn = 0;
            }

        }

    }
}
