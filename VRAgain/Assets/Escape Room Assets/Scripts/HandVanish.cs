using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVanish : MonoBehaviour {

    public MeshRenderer hand;  

    // Use this for initialization
    public void handVanish () {
        hand.enabled = false;
	}

    public void handAppear()
    {
        hand.enabled = true;
    }
}
