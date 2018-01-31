using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteZone : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Projectile" || coll.gameObject.tag == "EnemyProjectile")
            Destroy(coll.gameObject);
    }
}
