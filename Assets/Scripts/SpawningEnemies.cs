using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawningEnemies : Timer
{
    private bool isSpawning = false;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy1;
    [SerializeField]
    private GameObject enemy2;
    [SerializeField]
    private GameObject enemy3;

    private Vector3 spawnLocation;
    private Vector3 playerposition;
    private float enemyType;

    

    void Start()
    {
        spawnLocation.y = player.transform.position.y;
    }

    void Update()
    {
        if (!isSpawning)
        {
            
            StartCoroutine(nameof(SpawnEnemies));
        }
    }

    IEnumerator SpawnEnemies()
    {
        isSpawning = true;
        for (int i = 0; i < minutes + 1;  i++)
        {
            playerposition = player.transform.position;

            do //checking x value isn't too close to player
            {
                spawnLocation.x = playerposition.x + UnityEngine.Random.Range(-10, 10);
            } while (math.abs(spawnLocation.x) - 1.5 <= math.abs(playerposition.x) && math.abs(spawnLocation.x) + 1.5 >= math.abs(playerposition.x));

            do //checking z value isn't too close to player
            {
                spawnLocation.z = playerposition.z + UnityEngine.Random.Range(-6, 6);
            } while (math.abs(spawnLocation.z) - 1.5 <= math.abs(playerposition.z) && math.abs(spawnLocation.z) + 1.5 >= math.abs(playerposition.z));

            enemyType = UnityEngine.Random.Range(0, 3);
            if (enemyType < 1)
            {
                Instantiate(enemy1, spawnLocation, Quaternion.identity);
            }
            else if (enemyType < 2)
            {
                GameObject a = Instantiate(enemy2, spawnLocation, Quaternion.identity);
            }
            else
            {
                Instantiate(enemy3, spawnLocation, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(UnityEngine.Random.Range(1,5));
        isSpawning = false;
    }
}
