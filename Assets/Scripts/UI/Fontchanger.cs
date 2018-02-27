using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fontchanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var textComponents = Component.FindObjectsOfType<Text>();
        foreach (var component in textComponents)
        {
            //component.font = <Font hier>;
        }


    }
}
