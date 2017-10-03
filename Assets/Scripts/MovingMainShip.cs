using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMainShip : MonoBehaviour {

    Transform trans;

    float speed = 2f;
    bool activeR;
    bool activeL;
    bool facingRight = true;
    Rigidbody2D rigi;
	// Use this for initialization
	void Start () {
        trans = this.transform;
        rigi = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Old Stuff
        /*
        if (activeR && trans.position.x < 6.8)
        {
            trans.position += Vector3.right * speed;
        }
        else if (activeL && trans.position.x > -7.6)
        {
            trans.position += Vector3.left * speed;
        }
        */
        if (activeR && trans.position.x < 6.8)
        {
            rigi.AddForce(new Vector2(1 * speed, 0));
        }
        else if (activeL && trans.position.x > -7.6)
        {
            rigi.AddForce(new Vector2(-1 * speed, 0));
        }
        else
        {
            
            
        }
        if(trans.position.x < -7.6)
        {
            rigi.velocity = Vector3.zero;
        }
        if(trans.position.x > 6.8)
        {
            rigi.velocity = Vector3.zero;
        }
	}

    public void MoveRight()
    {
        activeR = !activeR;
        if (!facingRight)
        {
            FlipH();
        }
    }
    public void MoveLeft()
    {
        activeL = !activeL;
        if (facingRight)
        {
            FlipH();
        }
    }
    void FlipH()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
