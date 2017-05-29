using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilBehaviour : MonoBehaviour {

    int direction = 0; // 1 = up | 2 = down
    float speed = 0.3f;
    float dmg = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (direction == 1)
        {
            transform.position += Vector3.up * speed;
        }
        if (direction == 2)
        {
            transform.position += Vector3.down * speed;
        }
    }
    void SetDirection(int direction)
    {
        this.direction = direction; 
    }
    void SetDamage(float damage)
    {
        dmg = damage;
    }
    void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public float GetDmg()
    {
        return dmg;
    }

}
