using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokenPuzzle : MonoBehaviour {

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

    public void RandomizeCode()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                codeNumber = 5;
                break;

            case 1:
                codeNumber = 4;
                break;

            case 2:
                codeNumber = 3;
                break;

            case 3:
                codeNumber = 2;
                break;
        }
        randomCode = fourthE.randomCodes[rand];
    }

    public void Hint()
    {

    }
}
