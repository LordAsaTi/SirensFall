using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour {

    public float life = 100;
    public GameObject projectilPref;
    float maxLife;
    float coolDownInSec = 7f;
    bool dead = false;
    bool shooting = false;
    bool canShoot = true;
    bool goingRight = true;
    public int phase = 1;
    int direction = -1;
    int speed = 2;
    public MoveZones moveZones;
    GameObject player;
    Rigidbody2D rigi;

    // Use this for initialization
    void Start()
    {
        maxLife = life;
        player = GameObject.FindGameObjectWithTag("Player");
        rigi = GetComponent<Rigidbody2D>();
        StartCoroutine(Shoot());
        StartCoroutine(PhaseOne());
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!dead)
        {
            if (coll.gameObject.tag == "Projectile")
            {
                ProjectilBehaviour hitScript = coll.gameObject.GetComponent<ProjectilBehaviour>();
                Destroy(coll.gameObject);
                DmgTaken(hitScript.GetDmg());
            }
        }
    }
    IEnumerator PhaseOne()
    {
        transform.position = new Vector3(player.transform.position.x, 7.5f , 0);
        rigi.AddForce(new Vector2(0, -1 *20));
        while (transform.position.y > 4)
        {
            yield return null;
        }
        rigi.drag = 4;
        yield return new WaitForSeconds(0.5f);
        shooting = true;
        StartCoroutine(ShootSalve());
        while(phase == 1)
        {
            Moving();
            yield return null;
        }
        canShoot = false;
        
        StartCoroutine(PhaseTwo());
        yield return null;
    }

    IEnumerator PhaseTwo()
    {
        moveZones.StartMove();
        shooting = false;
        direction = 1;

        while (moveZones.getIsMoving())
        {
            yield return null;
        }
        rigi.drag = 0;
        rigi.AddForce(new Vector2(-1 * 100, 0));
        while(transform.position.x > -13)
        {
            yield return null;
        }
        rigi.velocity = Vector2.zero;
        transform.position = new Vector3(transform.position.x, -4.4f, 0);
        rigi.AddForce(Vector2.right * 150);
        while(transform.position.x < player.transform.position.x)
        {
            yield return null;
        }
        rigi.velocity = Vector2.zero;

        speed = 3;
        rigi.drag = 4;
        canShoot = true;
        StartCoroutine(ShootSalve());
        while(phase == 2)
        {
            Moving();
            yield return null;
        }
        yield return null;
    }
    void DmgTaken(float dmg)
    {
        life -= dmg;
        if (life <= 0 && !dead)
        {
            //GetComponent<SpriteRenderer>().color = Color.red;
            dead = true;
            phase++;
            StartCoroutine(Dead());
        }
    }
    void Attack(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ally")
        {
            coll.gameObject.SendMessage("Attacked");
        }

    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(coolDownInSec);
        dead = false;
        life = maxLife;
        //GetComponent<SpriteRenderer>().color = Color.green;
    }
    IEnumerator ShootSalve()
    {
        while (canShoot)
        {
            if (phase == 1)
            {
                yield return new WaitForSeconds(2f); 
            }
            if(phase == 2)
            {
                yield return new WaitForSeconds(1.5f);
            }
            shooting = !shooting;
        }
        

        shooting = false;


    }
    void Moving()
    {
        if (goingRight && transform.position.x < 6.8)
        {
            rigi.AddForce(new Vector2(1 * speed, 0));
        }
        else if (!goingRight && transform.position.x > -7.6)
        {
            rigi.AddForce(new Vector2(-1 * speed, 0));
        }
        else
        {
            goingRight = !goingRight;
        }
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            if(shooting)
            {
                GameObject projectil = Instantiate(projectilPref, new Vector3(transform.position.x, transform.position.y + (2f * direction), transform.position.z), transform.rotation);
                projectil.SendMessage("SetDirection", direction);
                /*if (direction == -1) 
                //animatorDown.SetTrigger("ShootUp");
                else
                    //animatorUp.SetTrigger("ShootUp");
                */
                yield return new WaitForSeconds(0.5f);
                    
            }
            yield return null;
        }
        
    }
}
