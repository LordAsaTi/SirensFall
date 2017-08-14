using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour {

    public Transform loadingCircle;
    public Transform textIndicator;
    public Transform textLoading;

    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;
    // Use this for initialization

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
            textIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            textLoading.gameObject.SetActive(true);
        }
        else
        {
            textLoading.gameObject.SetActive(false);
            textIndicator.GetComponent<Text>().text = "DONE!";
        }
        loadingCircle.GetComponent<Image>().fillAmount = currentAmount / 100;
	}
    void CooldownButton()
    {

    }
}
