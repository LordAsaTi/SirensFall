using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMainShip : MonoBehaviour {

    public GameObject projectilPref;
    public GameObject BombPref;
    [HideInInspector]
    public bool bombShoot;
    GameObject projectilUp;
    GameObject projectilDown;
    Transform myTransform;
    float laneHeight;

    void Start () {
        myTransform = GetComponent<Transform>();
        laneHeight = (Camera.main.orthographicSize * 2f) / 10;
        bombShoot = false;
	}
	

	void Update () {

	}
    public void ShootUp()
    {
        if (bombShoot)
        {
            Instantiate(BombPref, new Vector3(myTransform.position.x, myTransform.position.y + laneHeight * 2, 0),BombPref.transform.rotation);
        }
        else
        {
            projectilUp = Instantiate(projectilPref, new Vector3(myTransform.position.x, myTransform.position.y + 0.7f, myTransform.position.z), projectilPref.transform.rotation);
            projectilUp.SendMessage("SetDirection", 1);
        }
       
    }
    public void ShootDown()
    {
        if (bombShoot)
        {
            Instantiate(BombPref, new Vector3(myTransform.position.x, myTransform.position.y - laneHeight * 2, 0), BombPref.transform.rotation);
        }
        else
        {
            projectilDown = Instantiate(projectilPref, new Vector3(myTransform.position.x, myTransform.position.y - 0.7f, myTransform.position.z), myTransform.rotation);
            projectilDown.SendMessage("SetDirection", 2);
        }
    }
}
