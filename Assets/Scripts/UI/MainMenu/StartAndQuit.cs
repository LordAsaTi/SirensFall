using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAndQuit : MonoBehaviour {

	
	void Start () {
		
	}
    public void StartButton()
    {
        SceneManager.LoadScene(0);
    }
}
