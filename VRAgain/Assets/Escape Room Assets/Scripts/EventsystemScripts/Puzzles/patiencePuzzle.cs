using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patiencePuzzle : MonoBehaviour {

    public bool started;
    public bool active;
    public bool solved;
    public bool hintGiven;

    public AudioSource randomCode;
    public int codeNumber;

    public fourthEvent fourthE;
    public EventScript2 es2;
    public LockPoint lockP;

    public IEnumerator Begin()
    {
        yield return new WaitForSeconds(20f);
    }

    public void Hint()
    {

    }
}
