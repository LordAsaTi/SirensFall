using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShipBehaviour : MonoBehaviour {

    bool go = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (go)
        {
            transform.position += new Vector3(0.01f, 0, 0);
        }
	}
    public void Move()
    {
        transform.position = new Vector3(-11, 2.7f, 0);
        go = true;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        go = false;
        Destroy(coll.gameObject);
        GetComponent<SpriteRenderer>().color = Color.red;
    }

}
