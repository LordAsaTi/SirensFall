using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    public GameObject UIOver;
    Text score;
    Text highScore;

	void Start () {
        score = UIOver.transform.GetChild(4).GetComponent<Text>();
        highScore = UIOver.transform.GetChild(5).GetComponent<Text>();
    }
	
	// Update is called once per frame

    public void ShowEndscreen()
    {
        score.text += PlayerPrefs.GetFloat("Points").ToString();
        UIOver.SetActive(true);
        //Sternanimation hier
        highScore.text += PlayerPrefs.GetFloat("Points").ToString(); // muss noch geändert werden
    }
}
