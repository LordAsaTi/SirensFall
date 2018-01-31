using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMainShip : MonoBehaviour {

    public int health;
    public GameObject GameOverScreen;

	
	void OnTriggerEnter2D (Collider2D coll) {
		if(coll.tag == "EnemyProjectile")
        {
            health -= (int)coll.GetComponent<ProjectilBehaviour>().GetDmg();
            Destroy(coll.gameObject);
        }
        if(health <= 0)
        {
            GameOverScreen.SetActive(true);
            GetComponent<Collider2D>().enabled = false;
        }
	}
}
