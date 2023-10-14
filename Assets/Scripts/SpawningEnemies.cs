using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement pMovement;
    private bool isSpawning = false;
    private int spawnBoss = 0;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy1;
    [SerializeField]
    private GameObject enemy2;
    [SerializeField]
    private GameObject enemy3;
    [SerializeField]
    private GameObject boss;

    private Vector3 spawnLocation;
    private Vector3 playerposition;
    private float enemyType;
    private int minutes = 0;

    private void OnEnable()
    {
        Timer.UpdateMinutes += UpdateMinutes;
    }

    private void OnDisable()
    {
        Timer.UpdateMinutes -= UpdateMinutes;
    }

    void Start()
    {
        pMovement.enabled = true;
        spawnLocation.y = player.transform.position.y;
    }

    void Update()
    {
        if (!isSpawning)
        {
            
            StartCoroutine(nameof(SpawnEnemies));
        }
    }

    void UpdateMinutes()
    {
        //debug log checked- is working
        minutes++;
        if(minutes % 2 == 0)
        {
            spawnBoss = 1;
        }
    }

    IEnumerator SpawnEnemies()
    {
        isSpawning = true;
        for (int i = 0; i < minutes + 1 * 2 + spawnBoss;  i++)
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
            if (spawnBoss == 1)
            {
                Instantiate(boss, spawnLocation, Quaternion.identity);
                spawnBoss = 0;
            }else if (enemyType < 1)
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
        yield return new WaitForSeconds(UnityEngine.Random.Range(0,5));
        isSpawning = false;
    }
}
