using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPCShips : MonoBehaviour {

    public GameObject prefShip;
    Vector3[] laneVector = new Vector3[5]; // the white ones
    public float shipSpeed = 0.01f;
    public float timeBetweenSpawns;
    public int[] spawnArray;   //<- hier die Schiffposition eintragen.
    public bool spawnedAll = false;
    
    

    SpecialsMainShip specialsScript;


	// Use this for initialization
	void Start () {
        laneVector[0] = new Vector3(-10.5f, 6.14f, 0);
        laneVector[1] = new Vector3(-10.5f, 4.16f, 0);
        laneVector[2] = new Vector3(-10.5f, 2.1f, 0);
        laneVector[3] = new Vector3(-10.5f, 0.15f, 0);
        laneVector[4] = new Vector3(-10.5f, -1.85f, 0);

        specialsScript = FindObjectOfType<SpecialsMainShip>();
        StartCoroutine(ShipSpawning());
    }
	
	// Update is called once per frame
	void Update () {
        if(spawnedAll && GameObject.FindGameObjectWithTag("Ally") == null)
        {
            GetComponent<EndScreen>().ShowEndscreen();
            spawnedAll = false;
        }
	}

    public void SpawnShip(int lane)
    {
        GameObject ship = Instantiate(prefShip, laneVector[lane],this.transform.rotation ,this.transform);
        ship.SendMessage("Move",shipSpeed);
        specialsScript.SendMessage("UpdateAllyArray");
    }
    IEnumerator ShipSpawning()
    {
        for(int i = 0; i < spawnArray.Length; i++)
        { 
            SpawnShip(spawnArray[i]);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
        spawnedAll = true;
    }
}
