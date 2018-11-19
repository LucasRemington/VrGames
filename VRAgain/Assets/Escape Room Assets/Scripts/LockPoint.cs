using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPoint : MonoBehaviour {

    public Rigidbody rb;
    public bool triggerPress;
    public bool locked;
    public AudioSource lockIn;
    public AudioSource lockOut;
    public string parentName;

    public bool playerTouch;

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
            this.transform.parent = null;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("AILocker") && triggerPress == true)
        {
            this.transform.parent = other.transform;
            Debug.Log("locked");
            if (lockIn.isPlaying == false)
            {
                Debug.Log("play lockin");
                lockIn.Play(0);
            }
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            rb.useGravity = false;
            locked = true;
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
