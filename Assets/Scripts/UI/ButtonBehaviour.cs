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
        currentAmount = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentAmount < 100)
        {
            GetComponent<Button>().interactable = false;
            loadingCircle.gameObject.SetActive(true);
            currentAmount += speed * Time.deltaTime;
            textIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            textLoading.GetComponent<Text>().color = Color.grey;
        }
        else
        {
            GetComponent<Button>().interactable = true;
            loadingCircle.gameObject.SetActive(false);
            textLoading.GetComponent<Text>().color = Color.black;
            textIndicator.GetComponent<Text>().text = "";
        }
        loadingCircle.GetComponent<Image>().fillAmount = currentAmount / 100;
	}
    void SetCooldown(float time)
    {
        speed = time;
        currentAmount = 0;
    }
}
