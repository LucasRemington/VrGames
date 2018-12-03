using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heatedPuzzle : MonoBehaviour {

    public bool started;
    public bool active;
    public bool solved;

    public fourthEvent fourthE;
    public EventScript2 es2;
    public LockPoint lockP;

    public AudioSource StartHeat;
    public AudioSource HintsHeat;
    public AudioSource WateronHotHeat;
    public AudioSource CryoPluginHeat;
    public AudioSource WaterFreezeHeat;
    public AudioSource FreezeFinishHeat;
    public AudioSource SuccessHeat;

    public GameObject AI;

    public bool cryoVoice;

    public IEnumerator Begin()
    {
        yield return new WaitForSeconds(20f);
        started = true;
        fourthE.ActiveSetter(1); // 1 for active setter 
        es2.currentStop();
        es2.currentAudio = StartHeat;
        StartHeat.Play(0);
        //yield return new WaitUntil(() => es2.AIVoice[2].isPlaying == false);
    }

    public void PlayCryoVoice ()
    {

    }

    public void Hint()
    {
        es2.currentStop();
        es2.currentAudio = StartHeat;
        StartHeat.Play(0);
    }
}
