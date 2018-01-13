using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour {

    public GameObject OptionsMenu;

    public GameObject special1Zone;
    public GameObject special2Zone;
    public GameObject[] specialPref;
    public GameObject choiceContentPanel;
    
    private void CreateChoices()
    {
        for(int i = 0; i < specialPref.Length; i++)
        {
            if(i == PlayerPrefs.GetInt("spezial1"))
            {
                Instantiate(specialPref[i], special1Zone.transform);
            }
            else if (i == PlayerPrefs.GetInt("spezial2"))
            {
                Instantiate(specialPref[i], special2Zone.transform);
            }
            else
            {
                Instantiate(specialPref[i], choiceContentPanel.transform.GetChild(i));
            }
            
        }
    }

    private void EraseChoices()
    {
        for (int i = 0; i < choiceContentPanel.transform.childCount; i++)
        {
            if (choiceContentPanel.transform.GetChild(i).transform.childCount > 0)
            {
                Destroy(choiceContentPanel.transform.GetChild(i).transform.GetChild(0).gameObject);

            }
        }
        if(special1Zone.transform.childCount > 0)
        {
            Destroy(special1Zone.transform.GetChild(0).gameObject);
        }
        if (special2Zone.transform.childCount > 0)
        {
            Destroy(special2Zone.transform.GetChild(0).gameObject);
        }
    }

    public void Activate()
    {
        OptionsMenu.SetActive(true);
        CreateChoices();
    }
    public void Close()
    {
        EraseChoices();
        if(special1Zone.transform.childCount > 0 && special2Zone.transform.childCount > 0)
        {
            PlayerPrefs.SetInt("spezial1", special1Zone.transform.GetChild(0).GetComponent<SpecialPropertyScript>().indexNumber);
            PlayerPrefs.SetInt("spezial2", special2Zone.transform.GetChild(0).GetComponent<SpecialPropertyScript>().indexNumber);

        }
        OptionsMenu.SetActive(false);

    }
}
