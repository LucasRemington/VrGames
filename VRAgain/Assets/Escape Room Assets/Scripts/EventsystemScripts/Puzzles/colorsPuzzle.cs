using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorsPuzzle : MonoBehaviour {

    public bool started;
    public bool active;
    public bool solved;
    public bool hintGiven;

    public Buttonpresser bPress;
    public Buttonpresser bGreen;
    public Buttonpresser bRed;
    public Buttonpresser bYellow;
    public Buttonpresser bBlue;

    public AudioSource randomCode;
    public int codeNumber;
    public int[] colorArray = new int[6];
    public int buttonNumber;
    public bool rightArray;

    public AudioSource StartColor;
    public AudioSource FirstPress;
    public AudioSource SecondPress;
    public AudioSource[] ColorHints;
    public AudioSource[] ColorFail;
    public AudioSource[] ColorSucceed;

    public fourthEvent fourthE;
    public EventScript2 es2;
    public LockPoint lockP;

    public IEnumerator Begin()
    {
        Debug.Log("Color puzzle start");
        started = true;
        fourthE.ActiveSetter(4); // 4 for active setter 
        bPress.buttonActive= true;
        RandomizeCode();
        es2.currentStop();
        es2.currentAudio = StartColor;
        StartColor.Play(0);
        yield return new WaitUntil(() => bPress.buttonPushed == true);
        es2.currentStop();
        es2.currentAudio = FirstPress;
        FirstPress.Play(0);
        yield return new WaitUntil(() => colorArray[0] != 0);
        es2.currentStop();
        es2.currentAudio = SecondPress;
        SecondPress.Play(0);
        yield return new WaitUntil(() => rightArray == true);
    }

    public void ButtonCounter (int x)
    {
        colorArray[buttonNumber] = x;
        if (buttonNumber >= 6)
        {
           buttonNumber = 0;
           Debug.Log("button string is " + colorArray[0] + colorArray[1] + colorArray[2] + colorArray[3] + colorArray[4] + colorArray[5] + colorArray[6]);
           if (colorArray[0] == 2 && colorArray[1] == 3 && colorArray[2] == 3 && colorArray[3] == 1 && colorArray[4] == 2 && colorArray[5] == 4 && colorArray[6] == 1)
            {
                rightArray = true;
            }
        } else
        {
           buttonNumber++;
        }
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
