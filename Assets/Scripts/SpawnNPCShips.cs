using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPCShips : MonoBehaviour {

    public GameObject prefShip;
    public GameObject attentionTri;
    public EndScreen endscreen;

    Vector3[] laneVector = new Vector3[5]; // the white ones
    public float shipSpeed = 0.5f;
    public float timeBetweenSpawns;
    public int[] spawnArray;   //<- hier die Schiffposition eintragen.
    public bool spawnedAll = false;
    
    

    SpecialsMainShip specialsScript;


	// Use this for initialization
	void Start () {
        laneVector[0] = new Vector3(-10.5f, 5.64f, 0);
        laneVector[1] = new Vector3(-10.5f, 3.66f, 0);
        laneVector[2] = new Vector3(-10.5f, 1.65f, 0);
        laneVector[3] = new Vector3(-10.5f, -0.35f, 0);
        laneVector[4] = new Vector3(-10.5f, -2.35f, 0);

        
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
        ship.SendMessage("SetPointValue", 1);

        endscreen.AddMaxPoints(ship.GetComponent<NPCShipBehaviour>().getPointValue());
        specialsScript.SendMessage("UpdateAllyArray");
        StartCoroutine(SpawnTriangle(lane));
    }
    IEnumerator SpawnTriangle(int lane)
    {
        GameObject triangle = Instantiate(attentionTri,new Vector3(attentionTri.transform.position.x, laneVector[lane].y, 0), this.transform.rotation, this.transform);
        yield return new WaitForSeconds(1f);
        Destroy(triangle);
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
