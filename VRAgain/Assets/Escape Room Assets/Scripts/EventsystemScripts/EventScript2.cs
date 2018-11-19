using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScript2 : MonoBehaviour {

    public int eventSystem = 0; //int tracking which puzzles are active
   
    public firstEvent firstE; //scripts for each event
    public secondEvent secondE;
    public thirdEvent thirdE;

    public AudioSource[] AIVoice; // Audio files for narration
    public AudioSource currentAudio; // currently playing audio

    public AudioSource backgroundRumble; //background rumbling

    public AudioSource interCom; //Intercom SE
    public AudioSource partyHorn; // Horn SE


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
                StartCoroutine(secondE.Begin());
                break;

            case 2:
                StartCoroutine(thirdE.Begin());
                break;
            
        }
    }

    public void currentStop (){
        currentAudio.Stop();
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }

    }
