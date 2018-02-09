using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialsMainShip : MonoBehaviour {

    GameObject[] allyArray;
    float shieldDuration = 5f;
    float bombShotDuration = 5f;
    float mortarStartTime = 1f;
    float cooldown;
    GameObject ButtonSpez1;
    GameObject ButtonSpez2;
    public GameObject MortarPref;
    ShootMainShip shootScript;
    string spezName1 = "spezial1";
    string spezName2 = "spezial2";

    // Use this for initialization
    void Start () {
        ButtonSpez1 = GameObject.Find("Button Spezial 1");
        ButtonSpez2 = GameObject.Find("Button Spezial 2");

        if (PlayerPrefs.HasKey(spezName1))
        {
            ButtonSpez1.GetComponent<Button>().onClick.AddListener(delegate { SpezialSelect(PlayerPrefs.GetInt(spezName1)); });
        }
        else
        {
            PlayerPrefs.SetInt(spezName1, 0);
        }
        if (PlayerPrefs.HasKey(spezName2))
        {
            ButtonSpez2.GetComponent<Button>().onClick.AddListener(delegate { SpezialSelect(PlayerPrefs.GetInt(spezName2)); });
        }
        else
        {
            PlayerPrefs.SetInt(spezName2, 1);
        }


        shootScript = GetComponent<ShootMainShip>();
    }
	
    void UpdateAllyArray() //get called every spawn;
    {
        allyArray = GameObject.FindGameObjectsWithTag("Ally");
    }
    public void StartShield()
    {
        cooldown = 10f;
        StartCoroutine("ShieldAlly");
    }
    public void StartBombShoot()
    {
        cooldown = 15f;
        StartCoroutine(BombShoot());
    }
    public void StartMortar()
    {
        cooldown = 200f;
        StartCoroutine(MortarShoot());

    }
    public void SpezialSelect(int number)
    {
        switch (number)
        {
            case 0:
                StartShield();
                break;
            case 1:
                StartBombShoot();
                break;
            case 2:
                StartMortar();
                break;
            default:
                Debug.Log("false Input");
                break;
        }
    }
    void CooldownSetting(int type, float coolDown)
    {
        if(type == PlayerPrefs.GetInt(spezName1))
        {
            ButtonSpez1.SendMessage("SetCooldown", coolDown);
        }
        else if (type == PlayerPrefs.GetInt(spezName2))
        {
            ButtonSpez2.SendMessage("SetCooldown", coolDown);
        }
        else
        {
            Debug.Log("invalid SpezialNumber: " + type);
        }
    }
    IEnumerator ShieldAlly()  //auf jeden fall noch ändern so funktioniert es nur bedingt und die schüsse fliegen einfach durch, vll weiterer collider als unterobject der die projectiles löscht?
    {
        for(int i = 0; i < allyArray.Length; i++)
        {
            allyArray[i].GetComponent<Collider2D>().enabled = false;
            allyArray[i].transform.GetChild(0).gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(shieldDuration);
        for (int i = 0; i < allyArray.Length; i++)
        {
            allyArray[i].GetComponent<Collider2D>().enabled = true;
            allyArray[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        CooldownSetting(0, cooldown);
    }
    IEnumerator BombShoot()
    {
        shootScript.bombShoot = true;
        yield return new WaitForSeconds(bombShotDuration);
        shootScript.bombShoot = false;

        CooldownSetting(1, cooldown);
    }
    IEnumerator MortarShoot()
    {

#if UNITY_EDITOR
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        Vector3 posi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#else
        
        while(Input.touchCount == 0 || (Input.GetTouch(0).phase != TouchPhase.Began))
        {
            yield return null;
        }
        Vector3 posi = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif
        //hier Schuss start Animation
        yield return new WaitForSeconds(mortarStartTime);
        Instantiate(MortarPref,new Vector3(posi.x, posi.y, 0) , new Quaternion(0, 0, 0, 0));
        CooldownSetting(2, cooldown);
       
       
    }


}
