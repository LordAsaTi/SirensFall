using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        PlayerPrefs.SetFloat("Points", PlayerPrefs.GetFloat("Points") + coll.gameObject.GetComponent<NPCShipBehaviour>().getPointValue());
        Destroy(coll.gameObject);
    }
}
