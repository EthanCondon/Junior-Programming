using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2f;
    private float spawnInterval = 1.5f;

    private PlayerControllerX playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval); // fixed name
    }

    void SpawnObjects()
    {
        // random spawn position
        Vector3 spawnPos = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        if (!playerControllerScript.gameOver)
        {
            // spawn object with default upright rotation
            Instantiate(objectPrefabs[index], spawnPos, Quaternion.identity);
        }
    }
}
