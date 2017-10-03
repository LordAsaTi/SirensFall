using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMainShip : MonoBehaviour {

    public GameObject projectilPref;

    GameObject projectilUp;
    GameObject projectilDown;
    Transform myTransform;

	void Start () {
        myTransform = GetComponent<Transform>();
	}
	

	void Update () {

	}
    public void ShootUp()
    {
       projectilUp = Instantiate(projectilPref,new Vector3(myTransform.position.x, myTransform.position.y + 0.7f, myTransform.position.z), projectilPref.transform.rotation);
       projectilUp.SendMessage("SetDirection", 1);
    }
    public void ShootDown()
    {
        projectilDown = Instantiate(projectilPref, new Vector3(myTransform.position.x, myTransform.position.y - 0.7f, myTransform.position.z), myTransform.rotation);
        projectilDown.SendMessage("SetDirection", 2);
    }
}
