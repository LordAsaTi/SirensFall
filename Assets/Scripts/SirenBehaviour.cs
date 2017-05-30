﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenBehaviour : MonoBehaviour {

    public float life = 10;
    float maxLife;
    float coolDownInSec = 2.5f;
    private float timeStamp = 2.5f;
    bool dead = false;

	// Use this for initialization
	void Start () {
        maxLife = life;
	}
	
	// Update is called once per frame
	void Update () {
        if (dead && timeStamp <= Time.time)
        {
            dead = false;
            life = maxLife;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!dead) { 
            ProjectilBehaviour hitScript = coll.gameObject.GetComponent<ProjectilBehaviour>();
            Destroy(coll.gameObject);
            DmgTaken(hitScript.GetDmg());
        }
    }
    void DmgTaken(float dmg)
    {
        life -= dmg;
        if(life <= 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            timeStamp = Time.time + coolDownInSec;
            dead = true; 
        }
    }


}