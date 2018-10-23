using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemiesIndex;
    private GameObject currentEnemy;
    public float spawnTime;
    public int currentIndex;
#if UNITY_EDITOR
    public bool canChooseIndex = false;
#endif

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
            Spawn();
#endif
    }

    void Spawn()
    {
#if UNITY_EDITOR
        if (canChooseIndex != true)
#endif
            currentIndex = Random.Range(0, enemiesIndex.Length);
        currentEnemy = enemiesIndex[currentIndex];

        float spawnPoints = Random.Range(-3.5f, 3.5f);
        Vector3 spawnPoint = new Vector3(10f, spawnPoints, 0);

        Instantiate(currentEnemy, spawnPoint, Quaternion.identity);
    }
}
