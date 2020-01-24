﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
    {
    private Vector3 spawnPosition;
    public float timeBetweenWaves = 3;

    public List<GameObject> enemiesAlive = new List<GameObject>();

    private int dayCount = 0;

    public Day[] days;

    // Start is called before the first frame update
    private void Start()
        {
        StartCoroutine(SpawnDayWave());
        }

    // Update is called once per frame
    private void Update()
        {
        }

    private IEnumerator SpawnDayWave()
        {
        Day day = days[dayCount];

        for (int i = 0; i < day.count; i++)
            {
            SpawnEnemy(day.enemy);
            yield return new WaitForSeconds(timeBetweenWaves);
            }
        dayCount++;
        }

    private void SpawnEnemy(GameObject enemy)
        {
        spawnPosition = new Vector3(transform.position.x, transform.position.y + .5f, Random.Range(-3.3f, 3.3f));
        GameObject enemyAlive = Instantiate(enemy, spawnPosition, transform.rotation);
        AddAliveEnemy(enemyAlive);
        }

    private void AddAliveEnemy(GameObject enemy)
        {
        enemiesAlive.Add(enemy);
        }
    }