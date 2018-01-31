using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    public GameObject UIOver;
    Text score;
    Text highScore;
    string highScoreName;
    float maxPoints;

	void Start () {
        score = UIOver.transform.GetChild(4).GetComponent<Text>();
        highScore = UIOver.transform.GetChild(5).GetComponent<Text>();
        highScoreName = SceneManager.GetActiveScene().name + "_High"; //Example Level_1_High
    }
	
	// Update is called once per frame

    public void ShowEndscreen()
    {
        score.text += PlayerPrefs.GetFloat("Points").ToString();
        UIOver.SetActive(true);
        //Sternanimation hier
        if(PlayerPrefs.HasKey(highScoreName))
        {
            if(PlayerPrefs.GetFloat(highScoreName) < PlayerPrefs.GetFloat("Points"))
            {
                PlayerPrefs.SetFloat(highScoreName,PlayerPrefs.GetFloat("Points"));
            }
        }
        else
        {
            PlayerPrefs.SetFloat(highScoreName, PlayerPrefs.GetFloat("Points"));
        }
        highScore.text += PlayerPrefs.GetFloat(highScoreName).ToString();
    }
    int CalculateStars()
    {
        if(PlayerPrefs.GetFloat("Points") == maxPoints)
        {
            return 3;
        }
        else if(PlayerPrefs.GetFloat("Points") > maxPoints / 2)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
    public void AddMaxPoints(float toAdd)
    {
        maxPoints += toAdd;
    }

}
