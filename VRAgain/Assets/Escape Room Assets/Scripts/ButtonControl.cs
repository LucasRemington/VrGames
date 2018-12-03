using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{

    public GameObject ButtonPressing;
    public GameObject Dormant;
    public Animator anim;

    public void Swap()
    {
        Debug.Log("buttonswap");
        if (ButtonPressing.activeSelf == true)
        {
            ButtonPressing.SetActive(false);
            //Dormant.SetActive(true);
            anim.SetTrigger("Press");
            anim.SetBool("StartDormant", false);

        } else
        {
            ButtonPressing.SetActive(true); 
            anim.SetBool("StartDormant", true);
        }

    }

}
