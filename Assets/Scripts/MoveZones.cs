using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveZones : MonoBehaviour {

    public GameObject ShootUP;
    public GameObject ShootDown;
    GameObject Player;
    RectTransform shootUpTrans;
    RectTransform shootDownTrans;

	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        shootDownTrans = ShootDown.GetComponent<RectTransform>();
        shootUpTrans = ShootUP.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(MoveY(10));
        }
	}
    IEnumerator MoveY(int ySpeed)
    {
        for(int i = 0;i < 65; i++)
        {
            shootUpTrans.Translate(Vector3.up * ySpeed, Space.World);
            shootDownTrans.Translate(Vector3.up * ySpeed);
            Player.transform.Translate(Vector3.up * ySpeed * 0.014f);
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
        
    }
}
