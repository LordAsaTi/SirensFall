using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {

    public GameObject[] lanes;
    GameObject playerShip;
    ShootMainShip shootScript;
    SpawnNPCShips npcScript;

	void Start () {
        playerShip = GameObject.FindGameObjectWithTag("Player");
        shootScript = playerShip.GetComponent<ShootMainShip>();
        shootScript.enabled = false;
        npcScript = GetComponent<SpawnNPCShips>();
        StartCoroutine(Tut1());

	}
    IEnumerator Tut1()
    {
        //Hier begrüßung in Sprechblase von Spieler Charakter
        //aktiviere Makierung für seitenTasten
        yield return new WaitForSeconds(1);
        lanes[5].SetActive(true); // erkläre das ist deine Lane
        yield return new WaitForSeconds(2);
        shootScript.enabled = true; // erkläre schießen
        //kurze Testzeit
        for(int i = 0; i < lanes.Length; i++)//show all Lanes
        {
            lanes[i].SetActive(true);
        }
        //Erkläre lanes

        npcScript.enabled = true;//starte NPC Ship
        shootScript.enabled = false;
        Time.timeScale = 0; //sobald in linie mit spieler
        //erkläre 

        shootScript.enabled = true;
        //lass spieler npc ship abschießen 


        Time.timeScale = 1;


    }
}
