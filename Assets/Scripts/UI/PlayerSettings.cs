using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour {

    public GameObject OptionsMenu;

    public GameObject special1Zone;
    public GameObject special2Zone;
    public GameObject specialPref;
    public GameObject choiceContentPanel;
    public Sprite[] specialImages;
    public string[] specialsName;
    
    private void CreateChoices()
    {
        for(int i = 0; i < specialsName.Length; i++)
        {
            GameObject specialPanel = Instantiate(specialPref, choiceContentPanel.transform.GetChild(i));
            specialPanel.transform.GetChild(0).GetComponent<Image>().sprite = specialImages[i];
            specialPanel.GetComponentInChildren<Text>().text = specialsName[i];
        }
        
    }
    private void EraseChoices()
    {
        for (int i = 0; i < choiceContentPanel.transform.childCount; i++)
        {
            Debug.Log(i);
            if (choiceContentPanel.transform.GetChild(i).transform.childCount > 0)
            {
                Destroy(choiceContentPanel.transform.GetChild(i).transform.GetChild(0).gameObject);

            }
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
        OptionsMenu.SetActive(false);
    }
}
