using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] Spawnpoints; // vielleicht doch parent und get children?
    public float timeBetweenSpawns;
    public int maxEnemyCount;
    private int spawnCount;
    private float time = 0;
    private float nextSpawn = 0;
    // Update is called once per frame
    private void Start()
    {
        for (int i = 0; i < Spawnpoints.Length; i++)
        {
            Spawnpoints[i].SetActive(false);
        }
    }
    void Update () {
        time += Time.deltaTime;
		if(time > nextSpawn)
        {
            activateSirene((int)UnityEngine.Random.Range(0, Spawnpoints.Length - 1) );
            nextSpawn = nextSpawn + time + UnityEngine.Random.Range(timeBetweenSpawns, timeBetweenSpawns + 2f);
        }
	}

    private void activateSirene(int number)
    {
        if(spawnCount < maxEnemyCount)
        {
            if (Spawnpoints[number].activeSelf)
            {

                if (number > 0)
                {
                    activateSirene(number - 1);
                }
                else
                {
                    activateSirene(Spawnpoints.Length);
                }

            }
            else
            {
                Spawnpoints[number].SetActive(true);
                spawnCount++;
            }
        }
        
    }
}
