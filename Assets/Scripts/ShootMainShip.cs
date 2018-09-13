using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMainShip : MonoBehaviour {

    public GameObject projectilPref;
    public GameObject BombPref;
    [HideInInspector]
    public bool bombShoot;
    [HideInInspector]
    public bool mortarShoot;
    GameObject projectilDown;
    Transform myTransform;
    float laneHeight;
    Animator animatorUp;
    Animator animatorDown;
    private AudioSource source;
    public AudioClip shootClip;
    public AudioClip bombShootClip;

    void Start () {
        myTransform = GetComponent<Transform>();
        laneHeight = (Camera.main.orthographicSize * 2f) / 10;
        bombShoot = false;
        animatorUp = transform.GetChild(1).GetComponent<Animator>();
        animatorDown = transform.GetChild(2).GetComponent<Animator>();
        source = GetComponent<AudioSource>();
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
        
        if (bombShoot || mortarShoot)
        {
            if (bombShoot)
            {
                source.PlayOneShot(bombShootClip, 1);
                Instantiate(BombPref, new Vector3(myTransform.position.x, myTransform.position.y + (laneHeight * direction) * 4, -1), BombPref.transform.rotation);
            }
            
        }
        else
        {
            source.PlayOneShot(shootClip, 1);
            projectilDown = Instantiate(projectilPref, new Vector3(myTransform.position.x, myTransform.position.y + (0.7f * direction), myTransform.position.z), myTransform.rotation);
            projectilDown.SendMessage("SetDirection", direction);
            if(direction == -1)
                animatorDown.SetTrigger("ShootUp");
            else
                animatorUp.SetTrigger("ShootUp");
        }
    }
}
