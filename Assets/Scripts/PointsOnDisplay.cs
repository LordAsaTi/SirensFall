﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PointsOnDisplay : MonoBehaviour {

    Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();


        PlayerPrefs.SetFloat("Points", 0);
	}
	
	// Update is called once per frame
	void Update () {
        text.text = PlayerPrefs.GetFloat("Points").ToString();
	}
}
