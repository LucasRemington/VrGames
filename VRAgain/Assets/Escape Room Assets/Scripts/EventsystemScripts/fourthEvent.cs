using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fourthEvent : MonoBehaviour {

    public EventScript2 es2;
    public heatedPuzzle heatPuz;
    public patiencePuzzle patiPuz;
    public colorsPuzzle colrPuz;
    public brokenPuzzle brokPuz;

    public int currentActivePuzzle;

    public AudioSource[] AICallout;
    int callout = 0;
    public int numberOfCallouts;
    AudioSource compareAudio;

    public IEnumerator Begin()
    {
        es2.eventSystem = 4;
        Debug.Log("begin event 4");
        StartCoroutine(CalloutTimer());
        yield return new WaitUntil(() => (heatPuz.solved == true && patiPuz.solved == true && colrPuz.solved == true && brokPuz.solved == true));
    }

    public IEnumerator CalloutTimer()
    {
        Debug.Log("callout timer start");
        compareAudio = es2.currentAudio;
        yield return new WaitForSeconds(20f);
        callout++;
        if (compareAudio == es2.currentAudio && es2.eventSystem == 4)
        {
            //es2.currentStop();
            //es2.currentAudio = AICallout[callout];
            //AICallout[callout].Play(0);
            if (callout <= numberOfCallouts)
            {
                StartCoroutine(CalloutTimer());
            }
        } else if (es2.eventSystem == 4)
        {
            StartCoroutine(CalloutTimer());
        }
    }

    public void ActiveSetter (int x) // heat = 1 patience = 2 broken = 3 colors = 4
    {
        if (x == 1)
        {
            heatPuz.active = true;
            patiPuz.active = false;
            brokPuz.active = false;
            colrPuz.active = false;
            currentActivePuzzle = 1;
        } else if (x == 2)
        {
            heatPuz.active = false;
            patiPuz.active = true;
            brokPuz.active = false;
            colrPuz.active = false;
            currentActivePuzzle = 2;
        }
        else if (x == 3)
        {
            heatPuz.active = false;
            patiPuz.active = false;
            brokPuz.active = true;
            colrPuz.active = false;
            currentActivePuzzle = 3;
        }
        else if (x == 4)
        {
            heatPuz.active = false;
            patiPuz.active = false;
            brokPuz.active = false;
            colrPuz.active = true;
            currentActivePuzzle = 4;
        }
    }
}
