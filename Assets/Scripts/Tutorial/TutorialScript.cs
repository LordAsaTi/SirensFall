using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

    public GameObject[] lanes;
    public GameObject tutStuff;
    public string[] tutorialMessage;
    Image[] arrows;
    int indexText;
    Text tutText;
    GameObject playerShip;
    ShootMainShip shootScript;
    SpawnNPCShips npcScript;
    bool next;

	void Start () {
        playerShip = GameObject.FindGameObjectWithTag("Player");
        shootScript = playerShip.GetComponent<ShootMainShip>();
        shootScript.enabled = false;
        npcScript = GetComponent<SpawnNPCShips>();
        tutText = tutStuff.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        arrows = new Image[tutStuff.transform.childCount - 1];
        for(int i = 0; i < arrows.Length; i++)
        {
            arrows[i] = tutStuff.transform.GetChild(i + 1).GetComponent<Image>();
        }

        next = false;
        indexText = 0;
        StartCoroutine(Tut1());

	}
    public void pressedText()
    {
        next = true;
    }
    IEnumerator Tut1()
    {
        //Hier begrüßung in Sprechblase von Spieler Charakter
        while (!next)
        {
            yield return null;
        }
        next = false;
        tutText.text = tutorialMessage[indexText];
        arrows[0].enabled =  true;
        indexText++;
        while (!next)
        {
            yield return null;
        }
        next = false;
        arrows[0].enabled = false;
        arrows[1].enabled = true;
        arrows[2].enabled = true;
        tutText.text = tutorialMessage[indexText];
        indexText++;
        while (!next)
        {
            yield return null;
        }
        next = false;
        arrows[1].enabled = false;
        arrows[2].enabled = false;
        yield return new WaitForSeconds(1);
        lanes[5].SetActive(true); // erkläre das ist deine Lane
        tutText.text = tutorialMessage[indexText];
        indexText++;
        while (!next)
        {
            yield return null;
        }
        next = false;
        tutText.text = tutorialMessage[indexText];
        indexText++;
        yield return new WaitForSeconds(2);

        for(int i = 0; i < lanes.Length; i++)//show all Lanes
        {
            lanes[i].SetActive(true);
        }
        while (!next)
        {
            yield return null;
        }
        next = false;

        shootScript.enabled = true; // erkläre schießen


        npcScript.enabled = true;//starte NPC Ship
        shootScript.enabled = false;
        Time.timeScale = 0; //sobald in linie mit spieler
        //erkläre 

        shootScript.enabled = true;
        //lass spieler npc ship abschießen 


        Time.timeScale = 1;


    }
}
