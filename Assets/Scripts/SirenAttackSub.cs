using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenAttackSub : MonoBehaviour {

    public GameObject siren;
	// Use this for initialization
	void Start () {
        siren = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!siren.GetComponent<SirenBehaviour>().getDead()){
            siren.SendMessage("Attack", coll);
        }
    }
}
