using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{

    bool spawn = true;
    GameObject objectPrefab;
    [SerializeField] GameObject[] objectsPrefab;
    [SerializeField] float[] spawnPosArray;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] float ySpawn = 10f;

    Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while (spawn)
        {
            float timeBetweenSpawn = Random.Range(minSpawnDelay, maxSpawnDelay);
            objectPrefab = objectsPrefab[Random.Range(0, objectsPrefab.Length)];
            yield return new WaitForSeconds(timeBetweenSpawn);
            Spawner();
        }
    }


    private void Spawner()
    {
        GetNewPosition();
        var newObject = Instantiate(
                   objectPrefab,
                   spawnPos,
                   transform.rotation) as GameObject;
        newObject.transform.parent = transform;
    }

    private void GetNewPosition()
    {
        Vector2 spawnPosCandid;
        do
        { 
            spawnPosCandid = new Vector2(spawnPosArray[Random.Range(0, spawnPosArray.Length)], ySpawn);
        }
        while (spawnPosCandid == spawnPos);
        spawnPos = spawnPosCandid;
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }
}
