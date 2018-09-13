using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenBehaviour : MonoBehaviour {

    public float life = 10;
    float maxLife;
    float coolDownInSec = 7f;
    bool dead = false;
    Animator animator;
    SpriteRenderer sRender;

	// Use this for initialization
	void Start () {
        maxLife = life;
        animator = this.transform.GetChild(0).GetComponent<Animator>();
        sRender = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

	}
    public bool getDead()
    {
        return dead;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!dead) {
            if (coll.gameObject.tag == "Projectile")
            {
                ProjectilBehaviour hitScript = coll.gameObject.GetComponent<ProjectilBehaviour>();
                Destroy(coll.gameObject);
                DmgTaken(hitScript.GetDmg());
            }
        }
    }
    void DmgTaken(float dmg)
    {
        life -= dmg;

        StartCoroutine(FlashRed());
        if(life <= 0 && !dead)
        {
            //GetComponent<SpriteRenderer>().color = Color.red;
            animator.SetTrigger("Dies");
            dead = true;
            StartCoroutine(Dead());
        }
    }
    void Attack(Collider2D coll)
    {
        if(coll.gameObject.tag == "Ally")
        {
            coll.gameObject.SendMessage("Attacked");
        }
        
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(coolDownInSec);
        
        //GetComponent<SpriteRenderer>().color = Color.green;
        animator.SetTrigger("Alive");
        yield return new WaitForSeconds(1f);
        dead = false;
        life = maxLife;
    }
    IEnumerator FlashRed()
    {
        sRender.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sRender.color = Color.white;
    }


}
