using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMainShip : MonoBehaviour {

    public int health;
    public GameObject GameOverScreen;
    public Text Text;

	
	void OnTriggerEnter2D (Collider2D coll) {
		if(coll.tag == "EnemyProjectile")
        {
            health -= (int)coll.GetComponent<ProjectilBehaviour>().GetDmg();
            Destroy(coll.gameObject);
            Text.text = "" + health;
        }
        if(health <= 0)
        {
            GameOverScreen.SetActive(true);
            GetComponent<Collider2D>().enabled = false;
        }
	}
}
