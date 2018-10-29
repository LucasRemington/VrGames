using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonpresser : MonoBehaviour {

    Animator anim;
    public AudioSource buttonPush;
    public AudioSource drugButtonPush;
    //public CompareChecker butComp;


    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player"))
        {
           anim.SetTrigger("Press");
           //butComp.Check();
            if (Drugs.drugs <= 0)
            {
                buttonPush.Play(0);
            }
            else
            {
                drugButtonPush.Play(0);
            }
            
            
        }
	}
}
