using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTutorialProperty : NPCShipBehaviour
{
    TutorialScript tutScript;
    private void OnDestroy()
    {
        tutScript = GameObject.Find("TutorialController").GetComponent<TutorialScript>();
        tutScript.npcDied();
    }

}
