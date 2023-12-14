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
        SpawnEnemyObject();
        SpawnCollectibleObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyObject()
    {
        Instantiate(enemyObject, RandomSpawnPosition(), enemyObject.transform.rotation);
    }

    void SpawnCollectibleObject()
    {
        Instantiate(collectibleObject, RandomSpawnPosition(), collectibleObject.transform.rotation);
    }

    Vector3 RandomSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-areaRange, areaRange), 1f, Random.Range(-areaRange, areaRange));

        return spawnPosition;
    }
}
