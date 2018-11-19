using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdEvent : MonoBehaviour {

    //Plays third AI voice when player pulls it out of terminal. Waits until player plugs AI into watch, plays fourth AI voice.

    public EventScript2 es2;
    public GameTimer gameT;
    public LockPoint lockPoint;
    public AudioSource AIHint1;

    public IEnumerator Begin()
    {
        es2.eventSystem = 3;
        Debug.Log("begin event 3");
        StartCoroutine(HintTimer());
        yield return new WaitUntil(() => lockPoint.playerTouch == true);
        //es2.currentAudio = es2.AIVoice[2];
        Debug.Log("playvoice3");
        //es2.AIVoice[2].Play(0);
        yield return new WaitUntil(() => lockPoint.parentName == "Watch");
        es2.currentStop();
        //es2.currentAudio = es2.AIVoice[3];
        //es2.AIVoice[3].Play(0);
        //yield return new WaitUntil(() => es2.AIVoice[3].isPlaying == false);
        Debug.Log("playvoice4");
        StartCoroutine(gameT.TimerCount());
        Debug.Log("timerstart");
        es2.switchCheck();
    }

    // AI berates player after fifteen seconds have passed and they haven't picked him up
    public IEnumerator HintTimer()
    {
        yield return new WaitForSeconds(15f);
        if (lockPoint.playerTouch == false)
        {
            //es2.currentStop();
            //es2.currentAudio = AIHint1;
            //AIHint1.Play(0);
        }
    }
}
