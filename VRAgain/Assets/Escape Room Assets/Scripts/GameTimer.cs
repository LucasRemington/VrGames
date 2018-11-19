using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public EventScript2 es2;
    public TextMesh timerText;
    public int startTime;

    // Update is called once per frame
    public IEnumerator TimerCount()
    {
        yield return new WaitForSeconds(1.0f);
        startTime--;
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
