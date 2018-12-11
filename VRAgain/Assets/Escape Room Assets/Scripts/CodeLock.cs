﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour {

    public Rigidbody rb;
    public LockPoint lockP;

    public AudioSource finalHintAudio;
    public int codeNumber;

    //Relevant bools and sounds for plugging into and dropping out of terminals
    public bool triggerPress;
    public bool locked;
    public bool hintGiven;
    public bool talked;
    public AudioSource lockIn;
    public AudioSource lockOut;

	// Update is called once per frame
	void Update () {
        if (locked == true)
        {
            this.transform.localPosition = new Vector3(0, 0, 0.5f);
            this.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (lockP.triggerPress == true)
        {
            triggerPress = true;
        } else
        {
            triggerPress = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("locked");
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            if (lockOut.isPlaying == false && locked == true)
            {
                Debug.Log("play shutdown");
                lockOut.Play(0);
            }
            locked = false;
            talked = false;
            this.transform.parent = null;
        }
    }

    void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("AILocker") && triggerPress == true)
            {
                this.transform.parent = other.transform;
                Debug.Log("locked");
                if (lockIn.isPlaying == false && locked == false && talked == false)
                {
                    Debug.Log("play lockin");
                    StartCoroutine(soundOrder());
                }
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                rb.useGravity = false;
                locked = true;
            }
        }

    public IEnumerator soundOrder()
    {
        Debug.Log("name is NOT watch");
        if (transform.parent.name == "Watch")
        {
            lockIn.Play(0);
            yield return new WaitUntil(() => lockIn.isPlaying == false);
            Debug.Log("name is watch");
            finalHintAudio.Play(0);
            yield return new WaitUntil(() => finalHintAudio.isPlaying == false);
            hintGiven = true;
            talked = true;
        }
    }

}
