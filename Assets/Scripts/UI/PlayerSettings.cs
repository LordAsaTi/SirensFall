using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour {

    public GameObject OptionsMenu;

    public GameObject spezial1Zone;
    public GameObject spezial2Zone;
    public GameObject buttonPref;
    public GameObject choiceContentPanel;
    public string[] spezialsName;

    void AddChoice(string choiceName, UnityEngine.Events.UnityAction method)
    {
        GameObject button = Instantiate(buttonPref, choiceContentPanel.transform);
        button.GetComponent<ButtonPrefabScript>().label.text = choiceName;
        button.GetComponent<Button>().onClick.AddListener(method);
    }
    public void CreateChoices()
    {
        for(int i = 0; i < spezialsName.Length; i++)
        {
            AddChoice(spezialsName[i], ButtonAktion);
        }
        
    }
    void ButtonAktion()
    {
        Debug.Log("Peng");
    }
    public void Activate()
    {
        OptionsMenu.SetActive(true);
        CreateChoices();
    }
}
