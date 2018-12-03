using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public EventScript2 es2;
    public TextMesh timerText;
    public int startTime;
    public AudioSource AIFiveMin;
    public AudioSource AIOneMin;

    // Calls once per second
    public IEnumerator TimerCount()
    {
        yield return new WaitForSeconds(1.0f);
        startTime--;
        if (startTime == 300)
        {
            yield return new WaitUntil(() => es2.currentAudio.isPlaying == false);
            yield return new WaitForSeconds(0.5f);
            Debug.Log("five minutes remaining!");
            //es2.currentAudio = es2.FiveMin;
            //es2.FiveMin.Play(0);
        }
        else if (startTime == 60)
        {
            yield return new WaitUntil(() => es2.currentAudio.isPlaying == false);
            yield return new WaitForSeconds(0.5f);
            Debug.Log("one minute remaining!");
            //es2.currentAudio = es2.OneMin;
            //es2.OneMin.Play(0);
        }
        timerText.text = startTime.ToString();
        if (startTime <= 0)
        {
            es2.GameOver();
        } else
        {
            StartCoroutine(TimerCount());
        }
    }
}
