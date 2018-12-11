using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonpresser : MonoBehaviour {

    Animator anim;
    public bool leftHand; // true if on left hand
    public AudioSource buttonPush;
    public AudioSource dormantPush;
    public bool buttonActive;
    public bool buttonPushed;
    public colorsPuzzle colrPuz;
    public int color; //1 red 2 yellow 3 green 4 blue

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
    }
	
	void OnTriggerEnter (Collider other) {
        Debug.Log("touched");
        if (other.CompareTag("Player") && other.name == "LeftHand" && leftHand == false)
        {
            Pushed();
        }
        if (other.CompareTag("Player") && other.name == "RightHand" && leftHand == true)
        {
            Pushed();
        }
    }
    void Pushed ()
    {
        if (buttonActive == true)
        {
            anim.SetTrigger("Press");
            buttonPush.Play(0);
            buttonPushed = true;
            if (color != 0)
            {
                colrPuz.ButtonCounter(color);
            }
        }
        else
        {
            anim.SetTrigger("DormantPress");
            dormantPush.Play(0);
        }
    }
}
