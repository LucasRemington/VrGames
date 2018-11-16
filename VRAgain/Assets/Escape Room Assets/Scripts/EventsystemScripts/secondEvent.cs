using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondEvent : MonoBehaviour {

    public Animator cryoDoor;
    public EventScript2 es2;
    public bool doorActive;

    public AudioSource doorHiss;

	// Use this for initialization
	void Awake () {

    }

    public IEnumerator Begin()
    {
        es2.eventSystem = 2;
        Debug.Log("begin event 2");
        cryoDoor.SetTrigger("open");
        doorHiss.Play(0);
        doorActive = true;
        yield return new WaitUntil(() => doorActive == false);
        Debug.Log("playvoice2");
        //es2.AIVoice[1].Play(0);
    }

    public void teleportOut()
    {
        if (es2.eventSystem == 2)
        {
            doorActive = false;
            cryoDoor.SetTrigger("close");
        }
    }
}
