using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{

    public GameObject ButtonPressing;
    public GameObject Dormant;
    public Animator anim;

    public IEnumerator checkButton()
    {
        yield return new WaitForSeconds(2f);
        if (ButtonPressing.activeSelf == true && Dormant.activeSelf == true)
        {
            ButtonPressing.SetActive(false);
            yield return new WaitForSeconds(1f);
            anim.SetBool("StartDormant", true);
        }
    }

    public void Swap()
    {

        Debug.Log("buttonswap");
        if (ButtonPressing.activeSelf == true)
        {
            ButtonPressing.SetActive(false);
            anim.SetTrigger("Press");
            anim.SetBool("StartDormant", false);
            //StartCoroutine(checkButton());
        }
        else
        {
            ButtonPressing.SetActive(true);
            anim.SetBool("StartDormant", true);
            //StartCoroutine(checkButton());
        }

    }

}
