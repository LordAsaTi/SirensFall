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
        Shoot(1);
    }
    public void ShootDown()
    {
        Shoot(-1);
    }
    void Shoot(int direction)
    {
        if (bombShoot)
        {
            Instantiate(BombPref, new Vector3(myTransform.position.x, myTransform.position.y + (laneHeight * direction) * 4, 0), BombPref.transform.rotation);
        }
        else
        {
            projectilDown = Instantiate(projectilPref, new Vector3(myTransform.position.x, myTransform.position.y + (0.7f * direction), myTransform.position.z), myTransform.rotation);
            projectilDown.SendMessage("SetDirection", direction);
        }
    }
}
