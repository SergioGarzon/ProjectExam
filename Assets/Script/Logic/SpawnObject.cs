﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public float delay;
    public GameObject[] objectToSpawn;
    public ScorePlayer score;
    private GameController gameController;
    public DataLevelObjects dataLevel;

    private bool control;

    private void Start()
    {
        gameController = GameObject.Find("ObjectManager").GetComponent<GameController>();
        delay = dataLevel.timeSpawn;
        control = true;
        StartCoroutine(WaitToSpawn());
    }

    IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(delay);
        Spawn();
    }

    void Spawn()
    {
        if (control && score.score <= 100 && score.score >= 0 && gameController.getControlData())
        {
            Instantiate(objectToSpawn[Random.Range(0, dataLevel.cantObjectSpawn)],
            transform.position + new Vector3(0, Random.Range(0, 10), Random.Range(0, 10)), transform.rotation);


            StartCoroutine(WaitToSpawn());
        }        
    }

    
    public void CreateSpawnCoin()
    {
        int counter = 0;

        while(counter != 5)
        {
            Instantiate(objectToSpawn[0],
            transform.position + new Vector3(0, Random.Range(0, 10), Random.Range(0, 10)), transform.rotation);

            counter++;
        }
        
    }

    public void setControl()
    {
        control = false;
    }
}