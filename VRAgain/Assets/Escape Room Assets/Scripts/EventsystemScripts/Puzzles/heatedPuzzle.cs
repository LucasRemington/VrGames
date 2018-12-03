using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heatedPuzzle : MonoBehaviour {

    public bool started;
    public bool active;
    public bool solved;
    public bool hintGiven;

    public AudioSource randomCode;
    public int codeNumber;

    public fourthEvent fourthE;
    public EventScript2 es2;
    public LockPoint lockP;

    public AudioSource OwFuck;
    public AudioSource StartHeat;
    public AudioSource HintsHeat;
    public AudioSource WateronHotHeat;
    public AudioSource[] CryoPluginHeat;
    public AudioSource WaterFreezeHeat;
    public AudioSource FreezeFinishHeat;
    public AudioSource[] SuccessHeat;

    public GameObject AI;

    public int cryoVoice = 0;

    public IEnumerator Begin()
    {
        Debug.Log("Heated puzzle start");
        started = true;
        fourthE.ActiveSetter(1); // 1 for active setter 
        es2.currentStop();
        es2.currentAudio = OwFuck;
        OwFuck.Play(0);
        lockP.fireOut();
        yield return new WaitForSeconds(2.5f);
        es2.currentStop();
        es2.currentAudio = StartHeat;
        StartHeat.Play(0);
        yield return new WaitUntil(() => StartHeat.isPlaying == false);
        Debug.Log("bucket check");
        //this is where all that wacky fun bucket stuff happens. When the bucket is full and in the chamber...
        es2.currentStop();
        es2.currentAudio = WaterFreezeHeat;
        WaterFreezeHeat.Play(0);
        yield return new WaitUntil(() => WaterFreezeHeat.isPlaying == false && lockP.parentName == "CryoTerminal");
        //play animations for door
        es2.currentStop();
        es2.currentAudio = FreezeFinishHeat;
        FreezeFinishHeat.Play(0);
        yield return new WaitUntil(() => FreezeFinishHeat.isPlaying == false); //Plus the terminal cooldown, when I code that

    }

    public void PlayCryoVoice ()
    {
        if (cryoVoice == 0)
        {
            cryoVoice++;
            StartCoroutine(CryoWaiter());
        }
        else if (cryoVoice == 2)
        {
            cryoVoice++;
        }
    }

    public IEnumerator CryoWaiter()
    {
        es2.currentStop();
        if (cryoVoice == 1)
        {
            es2.currentAudio = CryoPluginHeat[0];
            yield return new WaitUntil(() => CryoPluginHeat[0].isPlaying == false);
        } else if (cryoVoice == 3)
        {
            es2.currentAudio = CryoPluginHeat[1];
            yield return new WaitUntil(() => CryoPluginHeat[1].isPlaying == false);
        }
        cryoVoice++;
    }

        public void Hint()
    {
        if (hintGiven == false)
        {
            Debug.Log("hint given");
            StartCoroutine(HintExtend());
            hintGiven = true;
        } else
        {
            Debug.Log("hint already given!");
        }
    }

    public IEnumerator HintExtend ()
    {
        if (es2.currentAudio.isPlaying == true)
        {
            yield return new WaitUntil(() => es2.currentAudio.isPlaying == false);
        }
        es2.currentAudio = HintsHeat;
        HintsHeat.Play(0);
        yield return new WaitForSeconds(15f);
        hintGiven = false;
    }
}
