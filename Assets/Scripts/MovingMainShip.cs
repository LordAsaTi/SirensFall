using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMainShip : MonoBehaviour {

    Transform trans;

    public float speed = 0.5f;
    bool activeR;
    bool activeL;
	// Use this for initialization
	void Start () {
        trans = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (activeR && trans.position.x < 6.8)
        {
            trans.position += Vector3.right * speed;
        }
        else if (activeL && trans.position.x > -7.6)
        {
            trans.position += Vector3.left * speed;
        }
	}

    public void MoveRight()
    {
        activeR = !activeR;
    }
    public void MoveLeft()
    {
        activeL = !activeL;
    }
}
