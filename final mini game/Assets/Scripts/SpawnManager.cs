using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int coinAmount = 10;
    public float areaRange = 45f;
    public GameObject collectibleObject;
    public GameObject enemyObject;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnEnemyObject();
        //StartCoroutine(SpawnRandomAmountOfEnemies());
        //SpawnCollectibleObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyObject()
    {
        Instantiate(enemyObject, RandomSpawnPosition(), enemyObject.transform.rotation);
    }

    public void SpawnCollectibleObject()
    {
        for(int i = 0; i < coinAmount; i++)
        {
            Instantiate(collectibleObject, RandomSpawnPosition(), collectibleObject.transform.rotation);
        }
        coinAmount = 2;
    }

    Vector3 RandomSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-areaRange, areaRange), 1f, Random.Range(-areaRange, areaRange));

        return spawnPosition;
    }

    IEnumerator SpawnRandomAmountOfEnemies()
    {
        while(true)
        {
            int randomSeconds = Random.Range(1, 8);

            yield return new WaitForSeconds(randomSeconds);

            int numberOfEnemies = Random.Range(1, 3);

            for(int i = 0; i < numberOfEnemies; i++)
            {
                Instantiate(enemyObject, RandomSpawnPosition(), enemyObject.transform.rotation);
            }
        } 
    }

    public void StartCreatingZombies()
    {
        StartCoroutine(SpawnRandomAmountOfEnemies());
    }
}
