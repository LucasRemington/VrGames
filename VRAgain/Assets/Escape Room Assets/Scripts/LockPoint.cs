﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPoint : MonoBehaviour {

    public Rigidbody rb;

    //Relevant scripts for puzzles and general evejnts
    public EventScript2 es2;
    public fourthEvent fourthE;
    public heatedPuzzle heatPuz;
    public patiencePuzzle patiPuz;
    public colorsPuzzle colrPuz;
    public brokenPuzzle brokPuz;

    //Relevant bools and sounds for plugging into and dropping out of terminals
    public bool triggerPress;
    public bool locked;
    public bool hintGiven;
    public AudioSource lockIn;
    public AudioSource lockOut;

    public string parentName;  //String that holds name of current parent

    public bool playerTouch; //Bool checks if player has touched it yet

    void Update()
    {
        if (locked == true)
        {
            this.transform.localPosition = new Vector3(0, 0, 0.5f);
            this.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.parent != null)
        {
            parentName = transform.parent.name;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("locked");
            playerTouch = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            if (lockOut.isPlaying == false && locked == true)
            {
                Debug.Log("play shutdown");
                lockOut.Play(0);
            }
            locked = false;
            hintGiven = false;
            this.transform.parent = null;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("AILocker") && triggerPress == true)
        {
            this.transform.parent = other.transform;
            Debug.Log("locked");
            if (lockIn.isPlaying == false && locked == false)
            {
                Debug.Log("play lockin");
                lockIn.Play(0);
            }
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            rb.useGravity = false;
            locked = true;
            if (es2.eventSystem == 4)
            {
                if (parentName == "HeatedTerminal" && heatPuz.started == false)
                {
                    Debug.Log("heated terminal start");
                    StartCoroutine(heatPuz.Begin());
                }
                else if (parentName == "TimedTerminal" && patiPuz.started == false)
                {
                    Debug.Log("timed terminal start");
                    StartCoroutine(patiPuz.Begin());
                }
                else if (parentName == "BrokenTerminal" && brokPuz.started == false)
                {
                    Debug.Log("broken terminal start");
                    StartCoroutine(brokPuz.Begin());
                }
                else if (parentName == "ColorsTerminal" && colrPuz.started == false)
                {
                    Debug.Log("colors terminal start");
                    StartCoroutine(colrPuz.Begin());
                }
                else if (parentName == "CryoTerminal")
                {
                    heatPuz.PlayCryoVoice();
                }
                else if (parentName == "Watch" && hintGiven == false) // heat = 1 patience = 2 broken = 3 colors = 4
                {
                    if (fourthE.currentActivePuzzle == 1)
                    {
                        heatPuz.Hint();
                        hintGiven = true;
                    } else if (fourthE.currentActivePuzzle == 2)
                    {
                        patiPuz.Hint();
                        hintGiven = true;
                    }
                    else if (fourthE.currentActivePuzzle == 3)
                    {
                        brokPuz.Hint();
                        hintGiven = true;
                    }
                    else if (fourthE.currentActivePuzzle == 4)
                    {
                        colrPuz.Hint();
                        hintGiven = true;
                    }
                }
            }
        }
    }

    public void triggerInpt()
    {
        StartCoroutine(triggerInput());
    }

    public IEnumerator triggerInput()
    {
        triggerPress = true;
        yield return new WaitForSeconds(0.1f);
        triggerPress = false;
    }
}
