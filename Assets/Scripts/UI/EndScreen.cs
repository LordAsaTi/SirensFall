using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    public GameObject UIOver;
    Text score;
    Text highScore;
    Image starFilling;
    string highScoreName;
    float maxPoints;
	void Start () {
        score = UIOver.transform.GetChild(2).GetComponent<Text>();
        highScore = UIOver.transform.GetChild(3).GetComponent<Text>();
        starFilling = UIOver.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        highScoreName = SceneManager.GetActiveScene().name + "_High"; //Example Level_1_High
    }
	
	// Update is called once per frame

    public void ShowEndscreen()
    {
        score.text += PlayerPrefs.GetFloat("Points").ToString();
        UIOver.SetActive(true);

        StartCoroutine(FillStars());
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
   
    public void AddMaxPoints(float toAdd)
    {
        maxPoints += toAdd;
    }
    IEnumerator FillStars()
    {
        for (float i = 0; i < (PlayerPrefs.GetFloat("Points") / maxPoints); i += 0.1f)
        {
            starFilling.fillAmount = i;
            yield return new WaitForSeconds(0.2f);
        }
    }

}
