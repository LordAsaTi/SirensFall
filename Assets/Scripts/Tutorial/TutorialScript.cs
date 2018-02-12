using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

    public GameObject[] lanes;
    public GameObject tutStuff;
    [TextArea]
    public string[] tutorialMessage;
    public GameObject shootUpZone;
    public GameObject shootDownZone;
    public GameObject enemy;
    Image[] arrows;
    int indexText;
    Text tutText;
    GameObject playerShip;
    GameObject textPanel;
    ShootMainShip shootScript;
    SpawnNPCShips npcScript;
    bool next;
    bool npcDead;
    EndScreen endscreen;

	void Start () {
        playerShip = GameObject.FindGameObjectWithTag("Player");
        shootUpZone.SetActive(false);
        shootDownZone.SetActive(false);
        shootScript = playerShip.GetComponent<ShootMainShip>();
        shootScript.enabled = false;
        npcScript = GetComponent<SpawnNPCShips>();
        tutText = tutStuff.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        textPanel = tutStuff.transform.GetChild(0).gameObject;
        arrows = new Image[tutStuff.transform.childCount - 1];
        endscreen = GetComponent<EndScreen>();
        for(int i = 0; i < arrows.Length; i++)
        {
            arrows[i] = tutStuff.transform.GetChild(i + 1).GetComponent<Image>();
        }

        next = false;
        npcDead = false;
        indexText = 0;
        StartCoroutine(Tut1());

	}
    public void pressedText()
    {
        next = true;
    }
    public void npcDied()
    {
        npcDead = true;
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
        yield return new WaitForSeconds(1);

        for(int i = 0; i < lanes.Length; i++)//show all Lanes
        {
            lanes[i].SetActive(true);
        }
        while (!next)
        {
            yield return null;
        }
        next = false;
        tutText.text = tutorialMessage[indexText];
        indexText++;
        for (int i = 0; i < lanes.Length; i++)//hide all Lanes
        {
            lanes[i].SetActive(false);
        }
        while (!next)
        {
            yield return null;
        }
        next = false;

        npcScript.enabled = true;//starte NPC Ship
        yield return new WaitForSeconds(1);
        NPCShipBehaviour npcBehaviour = GameObject.FindWithTag("Ally").GetComponent<NPCShipBehaviour>();
        yield return new WaitForSeconds(11);
        npcBehaviour.SetGo();       //NPCSchiff stoppt


        tutText.text = tutorialMessage[indexText];
        indexText++;
        npcScript.enabled = false;//verhindert Endscreen
        shootScript.enabled = true; // erkläre schießen
        shootUpZone.SetActive(true);
        shootDownZone.SetActive(true);

        while (!npcDead) //Bis das NPC Schiff zerstört ist, geht es nicht weiter
        {
            yield return null;
        }

        tutText.text = tutorialMessage[indexText]; //wir wollen die Schiffe nicht abschießen
        indexText++;
        while (!next)
        {
            yield return null;
        }
        next = false;

        enemy.SetActive(true);

        tutText.text = tutorialMessage[indexText]; //dies ist eine Sirene
        indexText++;
        while (!next)
        {
            yield return null;
        }
        next = false;

        tutText.text = tutorialMessage[indexText]; //Beschütze das Schiff
        indexText++;

        npcScript.infinite = true;
        npcScript.spawnedAll = false;
        npcScript.enabled = true;//starte NPC Ship
        npcScript.RestartSpawning();
        
        while(PlayerPrefs.GetFloat("Points") < 1)
        {
            yield return null;
        }
        npcScript.enabled = false;
        endscreen.ShowEndscreen(); //endscreen erklärung ab hier
        yield return new WaitForSeconds(1f);
        arrows[3].enabled = true;
        tutText.text = tutorialMessage[indexText];
        indexText++;
        next = false;
        while (!next)
        {
            yield return null;
        }
        next = false;
        arrows[3].enabled = false;
        tutText.text = tutorialMessage[indexText];
        indexText++;
        arrows[4].enabled = true;

        while (!next)
        {
            yield return null;
        }
        next = false;
        arrows[4].enabled = false;
        tutText.text = tutorialMessage[indexText];
        indexText++;
        while (!next)
        {
            yield return null;
        }
        next = false;
        textPanel.SetActive(false);
        arrows[5].enabled = true;
    }
}
