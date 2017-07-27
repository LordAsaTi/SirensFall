using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentBehaviour : MonoBehaviour {

    private Animator turAnimator;

    public float shootDelay = 2f;
    public bool alive = true;
    public GameObject projectilPref;
    GameObject projectil;
    // Use this for initialization
    void Start () {
        turAnimator = GetComponent<Animator>();
        StartCoroutine("ShootingTime", shootDelay);

    }
	
	// Update is called once per frame
	void Update () {
	}

    void Shoot()
    {
        projectil = Instantiate(projectilPref, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), transform.rotation);
        projectil.SendMessage("SetSpeed", 0.1f);
        projectil.SendMessage("SetDirection", 1);    
    }

    IEnumerator ShootingTime(float waitTime)
    {
        while (alive)
        {
           yield return new WaitForSeconds(waitTime);
            turAnimator.SetTrigger("shootOnce");
            yield return new WaitForSeconds(0.6f);
            Shoot();
        } 
    }
}
