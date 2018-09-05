using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldProgressScript : MonoBehaviour {

    public Image[] ways;
    public GameObject[] buttons;

    public void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        for (int i = 0; i < ways.Length; i++)
        {
            ways[i].fillAmount = 0;
            if (PlayerPrefs.HasKey("LevelProgress"))
                if(PlayerPrefs.GetInt("LevelProgress") > i)
                    ways[i].fillAmount = 1;
                
        }

        if (PlayerPrefs.HasKey("LevelProgress"))
        {
            for (int i = 0; i <= PlayerPrefs.GetInt("LevelProgress"); i++)
            {
                buttons[i].SetActive(true);
                StartCoroutine(Filler(i));
            }
            
        }
        else
        {
            PlayerPrefs.SetInt("LevelProgress", 0);
            buttons[0].SetActive(true);
            for (int i = 1; i < ways.Length; i++)
            {
                ways[i].fillAmount = 0;
            }
            
        }
    }

    IEnumerator Filler(int i)
    {
        while(ways[i].fillAmount < 1)
        {
            ways[i].fillAmount += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
