using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldMapSceneManager : MonoBehaviour {

	public void LoadLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
