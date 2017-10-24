using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShipBehaviour : MonoBehaviour {

    float pointValue = 1;

    bool go = false;
    public float speed = 0.01f;
    //Vector3 startTrans;
	// Use this for initialization
	void Start () {
        //startTrans = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        if (go)
        {
            transform.position += new Vector3(1 * speed, 0, 0);
        }
	}
    public void Move(float speed)
    {
        //transform.position = startTrans;//new Vector3(-11, 2.7f, 0);
        this.speed = speed;
        go = true;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (GetComponent<BoxCollider2D>().isActiveAndEnabled) {
            if(coll.gameObject.tag == "Projectile")
                    {
                        Attacked();
                        Destroy(coll.gameObject);
                    }
        }        
    }
    void Attacked()
    {
        go = false;
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(Despawn());
    }
    public float getPointValue()
    {
        return pointValue;
    }
    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

}
