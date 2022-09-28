﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnPoint;
    public Transform allEnemy;

    private int rand;
    private int randPosition;
    public float startTimeBtwSpawns;
    private float timeBtwSpawn;
    

    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpawn = startTimeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwSpawn <= 0)
        {
            
            rand = Random.Range(0, enemy.Length);
            randPosition = Random.Range(0, spawnPoint.Length);
            var newEnemy = Instantiate(enemy[rand], spawnPoint[randPosition].transform.position,Quaternion.identity);
            newEnemy.transform.parent = allEnemy.transform;
            timeBtwSpawn = startTimeBtwSpawns;
            
        }
        else
            timeBtwSpawn -= Time.deltaTime;
    }

   
}
