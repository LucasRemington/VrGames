using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPoint : MonoBehaviour {

    public Rigidbody rb;
    public bool triggerPress;
    public bool locked;

    void Update()
    {
        if (locked == true)
        {
            this.transform.localPosition = new Vector3(0, 0, 0.5f);
            this.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            locked = false;
            //this.transform.parent = other.transform;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("AILocker") && triggerPress == true)
        {
            this.transform.parent = other.transform;
            Debug.Log("locked");
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
