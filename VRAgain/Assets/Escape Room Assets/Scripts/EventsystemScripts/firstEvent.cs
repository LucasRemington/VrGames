using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstEvent : MonoBehaviour {

    public EventScript2 es2;

	void Start () {
		
	}

    public IEnumerator Begin()
    {
        es2.AIVoice[0].Play(0);
        yield return new WaitUntil(() => es2.AIVoice[0].isPlaying == false);
        es2.eventSystem = 1;
        es2.switchCheck();
    }
}
