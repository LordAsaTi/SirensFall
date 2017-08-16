using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialsMainShip : MonoBehaviour {

    GameObject[] allyArray;
    float shieldDuration = 5f;
    float cooldown;
    GameObject ButtonSpez1;
	// Use this for initialization
	void Start () {
        ButtonSpez1 = GameObject.Find("Button Spezial 1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void UpdateAllyArray() //get called every spawn;
    {
        allyArray = GameObject.FindGameObjectsWithTag("Ally");
    }
    public void startShield()
    {
        cooldown = 10f;
        StartCoroutine("ShieldAlly");
    }
    public IEnumerator ShieldAlly()  //auf jeden fall noch ändern so funktioniert es nur bedingt und die schüsse fliegen einfach durch, vll weiterer collider als unterobject der die projectiles löscht?
    {
        ButtonSpez1.SendMessage("SetCooldown", cooldown);
        for(int i = 0; i < allyArray.Length; i++)
        {
            allyArray[i].GetComponent<Collider2D>().enabled = false;
            allyArray[i].transform.GetChild(0).gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(shieldDuration);
        for (int i = 0; i < allyArray.Length; i++)
        {
            allyArray[i].GetComponent<Collider2D>().enabled = true;
            allyArray[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
