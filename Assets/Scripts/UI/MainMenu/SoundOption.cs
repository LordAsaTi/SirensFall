using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour {

    bool AudioOn = true;
    GameObject SoundOn;
    GameObject SoundOff;

	// Use this for initialization
	void Start () {
        SoundOff = GameObject.Find("SoundOff");
        SoundOn = GameObject.Find("SoundOn");
        SoundOff.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SwitchSound()
    {
        if (AudioOn)
        {
            AudioListener.volume = 0;
            AudioListener.pause = true;
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);
        }
        else
        {
            AudioListener.volume = 1;
            AudioListener.pause = false;
            SoundOff.SetActive(false);
            SoundOn.SetActive(true);
        }
        AudioOn = !AudioOn;

    }
}
