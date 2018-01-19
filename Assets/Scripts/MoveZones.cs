using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveZones : MonoBehaviour {

    public GameObject ShootUP;
    public GameObject ShootDown;
    public GameObject Boss;
    GameObject Player;
    RectTransform shootUpTrans;
    RectTransform shootDownTrans;
    bool isUp;
    bool isMoving;

	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        shootDownTrans = ShootDown.GetComponent<RectTransform>();
        shootUpTrans = ShootUP.GetComponent<RectTransform>();
        isUp = false;
        isMoving = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") && !isMoving)
        {
            
            
        }
    }
    IEnumerator MoveY(int ySpeed)
    {
        isMoving = true;
        if (isUp)
        {
            while (Player.transform.position.y > -4.4)
            {
                MoveStuff(ySpeed);
                yield return null;
            }
        }
        else
        {
            while (Player.transform.position.y < 4.4)
            {
                MoveStuff(ySpeed);
                yield return null;
            }
        }
        isMoving = false;
        isUp = !isUp;
        yield return null;
        
    }
    void MoveStuff(int ySpeed)
    {
        shootUpTrans.Translate(Vector3.up * ySpeed, Space.World);
        shootDownTrans.Translate(Vector3.up * ySpeed);
        Player.transform.Translate(Vector3.up * ySpeed * 0.014f); // 0.014 seams to be the equallity to 1 in GUI
        Boss.transform.Translate(Vector3.up * ySpeed * 0.014f);
    }
    public void StartMove()
    {
        if (isUp)
        {
            StartCoroutine(MoveY(-1));
        }
        else
        {
            StartCoroutine(MoveY(1));
        }
    }
}
