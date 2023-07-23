using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    // Boolean indicating whether to continue spawning objects
    bool spawn = true;

    // List of game objects that have been spawned and should not be spawned again
    List<GameObject> blackList = new List<GameObject>();

    // Reference to the game object prefab to spawn
    GameObject objectPrefab;

    [SerializeField] float timeInBlakList = 5f;

    // Array of game object prefabs to choose from randomly
    [SerializeField] GameObject[] objectsPrefab;

    // Array of x positions to spawn objects at
    [SerializeField] float[] spawnPosArray;

    // Minimum delay between spawns
    [SerializeField] float minSpawnDelay = 1f;

    // Maximum delay between spawns
    [SerializeField] float maxSpawnDelay = 5f;

    // Y position to spawn objects at
    [SerializeField] float ySpawn = 10f;

    // Current spawn position
    Vector2 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(Spawn());
    }

    // Coroutine that spawns enemies
    IEnumerator Spawn()
    {
        while (spawn)
        {
            // Choose a random time to wait before spawning the next object
            float timeBetweenSpawn = Random.Range(minSpawnDelay, maxSpawnDelay);

            // Choose a random object prefab that is different from the last one
            do
            {
                objectPrefab = objectsPrefab[Random.Range(0, objectsPrefab.Length)];
            } while (Inblacklist(objectPrefab));

            // Add the chosen object prefab to the blacklist to prevent it from being spawned again immediately
            AddToBlackList(objectPrefab);

            // Wait for the specified time before spawning the object
            yield return new WaitForSeconds(timeBetweenSpawn);
            Spawner();
        }
    }

    // Check if the given object prefab is in the blacklist
    private bool Inblacklist(GameObject objectPrefab)
    {
        if (blackList.Contains(objectPrefab))
        {
            return true;
        }
        return false;
    }

    // Add the given object prefab to the blacklist for a fixed amount of time
   void AddToBlackList(GameObject objectPrefab)
    {
        blackList.Add(objectPrefab);
        if (blackList.Count > 3) {
            blackList.RemoveAt(0);
        }
    }

    // Spawn a new object at the current spawn position
    private void Spawner()
    {
        GetNewPosition();
        var newObject = Instantiate(
                   objectPrefab,
                   spawnPos,
                   transform.rotation) as GameObject;
        newObject.transform.parent = transform;
    }

    // Choose a new spawn position that is different from the previous one
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

    // Stop spawning objects
    public void StopSpawning()
    {
        StopAllCoroutines();
    }
}