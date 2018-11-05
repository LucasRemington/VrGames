using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScript2 : MonoBehaviour {

    public int eventSystem = 0; //int tracking which puzzles are active

    public firstEvent firstE; //scripts for each event

    public AudioSource[] AIVoice; // Audio files for narration


	void Start () {
        switchCheck(); // Calls switchcheck
	}

    // Update is called once per frame
    public void switchCheck () {
        switch (eventSystem)
        {
            case 0:
                StartCoroutine(firstE.Begin());
                break;

            case 1:
                StartCoroutine(firstE.Begin());
                break;

            case 2:
                StartCoroutine(firstE.Begin());
                break;
            
        }
    }

    }
