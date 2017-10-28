using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilBehaviour : MonoBehaviour {

    int direction = 0; // 1 = up | -1 = down
    float speed = 3f;
    float dmg = 1;
	// Use this for initialization
	void Start () {
		if(direction == -1)
        {
            transform.Rotate(new Vector3(0, 0, 180));
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (direction == 1)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (direction == -1)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
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
