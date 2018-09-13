using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldMapSceneManager : MonoBehaviour {

    public GameObject LoadingScreen;
    public Slider slider;

	public void LoadLevel(int sceneNumber)
    {
        if(LoadingScreen != null)
        {
            StartCoroutine(LoadAsynchronously(sceneNumber));
        }
        else
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            yield return null;
        }
    }
    
}
