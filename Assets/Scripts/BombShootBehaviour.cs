using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShootBehaviour : MonoBehaviour {


    public float dmg; //{ get; set; }
    float stay = 1;
 
	void Start () {
        dmg = 10;
        StartCoroutine(Explosion());
	}
    void Update()
    {

    }
	IEnumerator Explosion()
    {
        yield return new WaitForSeconds(stay);
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<SirenBehaviour>() != null)
        {
            coll.gameObject.SendMessage("DmgTaken", dmg);
        }
        
    }
}
