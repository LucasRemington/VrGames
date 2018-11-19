using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonpresser : MonoBehaviour {

    Animator anim;
    public bool leftHand; // true if on left hand
    public AudioSource buttonPush;

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
        anim.SetTrigger("Press");
        buttonPush.Play(0);
    }
}
