﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketLock : MonoBehaviour {

    public fourthEvent fourthE;
    public secondEvent secondE;
    public EventScript2 es2;
    public LockPoint lockP;
    public heatedPuzzle heatPuz;
    public int talked = 0;

    public bool filled;
    public bool cold;
    public bool steamHint;

    public int angleToTip;

    //public Material bucket;
    public AudioSource freezeSound;
    public AudioSource steam;

    public string parentName;  //String that holds name of current parent


    void Update()
    {
        if (transform.parent != null)
        {
            parentName = transform.parent.name;
            if (parentName == "Player" && es2.eventSystem == 4 && heatPuz.started == true)
            {
                Debug.Log("bucketpickup");
                fourthE.ActiveSetter(1);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeakyPipe"))
        {
            filled = true;
            Debug.Log("bucket full");
            StartCoroutine(BucketStable());
            //bucket.SetColor("_Color", Color.green);
        }
        if (other.CompareTag("Heated") && cold == false)
        {
            filled = false;
            Debug.Log("water not ice");
            steam.Play(0);
            if (steamHint == false)
            {
                es2.currentStop();
                es2.currentAudio = heatPuz.WateronHotHeat;
                heatPuz.WateronHotHeat.Play(0);
                steamHint = true;
            }
        }
        if (transform.parent != null && other.CompareTag("Freezing") && filled == true && talked == 0)
        {
            Debug.Log("readytofreeze");
            StartCoroutine(BucketFreeze());
            talked++;
            heatPuz.canCryo = true;
        }
        if (other.CompareTag("Heated") && cold == true)
        {
            steam.Play(0);
            heatPuz.coolTerminal = true;
            Destroy(this.gameObject);
        }
    }


    public IEnumerator BucketStable()
    {
        yield return new WaitUntil(() => ((this.transform.rotation.eulerAngles.y == angleToTip || this.transform.rotation.eulerAngles.y == angleToTip)) && cold == false);
        Debug.Log("bucket tipped out");
        filled = false;
        //bucket.SetColor("_Color", Color.red);
    }

    public IEnumerator BucketFreeze()
    {
        es2.currentStop();
        if (lockP.parentName == "CryoTerminal")
        {
            es2.currentAudio = heatPuz.WaterFreezeAlt;
            heatPuz.WaterFreezeAlt.Play(0);
        }
        else
        {
            es2.currentAudio = heatPuz.WaterFreezeHeat;
            heatPuz.WaterFreezeHeat.Play(0);
        }
        yield return new WaitUntil(() => heatPuz.WaterFreezeHeat.isPlaying == false && lockP.parentName == "CryoTerminal");
        secondE.cryoDoor.SetTrigger("close");
        secondE.doorHiss.Play(0);
        yield return new WaitUntil(() => secondE.doorHiss.isPlaying == false);
        freezeSound.Play(0);
        yield return new WaitForSeconds(5f);
        cold = true;
        freezeSound.Stop();
        secondE.cryoDoor.SetTrigger("open");
        secondE.doorHiss.Play(0);
        es2.currentStop();
        es2.currentAudio = heatPuz.FreezeFinishHeat;
        heatPuz.FreezeFinishHeat.Play(0);
        yield return new WaitUntil(() => heatPuz.FreezeFinishHeat.isPlaying == false);
        heatPuz.canCryo = false;
    }

}
