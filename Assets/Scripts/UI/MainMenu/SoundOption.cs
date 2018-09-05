using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour {

    bool AudioOn = true;
    GameObject SoundOn;
    GameObject SoundOff;
    public bool inLevel = true;

	// Use this for initialization
	void Start () {
        if (!inLevel)
        {
            SoundOff = GameObject.Find("SoundOff");
            SoundOn = GameObject.Find("SoundOn");
            SoundOff.SetActive(false);
        }
        
        if (PlayerPrefs.HasKey("AudioOn"))
        {
            if (PlayerPrefs.GetInt("AudioOn") == 1)
            {
                AudioOn = true;
            }
            else
            {
                AudioOn = false;
            }
            ConfigAudio();
        }
        else
        {
            PlayerPrefs.SetInt("AudioOn", 1);
        }
        ; // 1 = On 0 = Off
    }
	
    public void SwitchSound()
    {
        
        AudioOn = !AudioOn;
        ConfigAudio();
        SaveAudio();

    }
    private void ConfigAudio()
    {
        if (!AudioOn)
        {
            AudioListener.volume = 0;
            AudioListener.pause = true;
            if (!inLevel)
            {
                SoundOn.SetActive(false);
                SoundOff.SetActive(true);
            }
            
        }
        else
        {
            AudioListener.volume = 1;
            AudioListener.pause = false;
            if (!inLevel)
            {
                SoundOff.SetActive(false);
                SoundOn.SetActive(true);
            }
            
        }
    }
    public void SaveAudio()
    {
        if (AudioOn)
        {
            PlayerPrefs.SetInt("AudioOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("AudioOn", 0);
        }
    }
        
}
