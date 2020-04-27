using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = transform.GetComponent<Animator>();
    }

    public void ShowCredits()
    {
        anim.SetBool("credits", true);
    }

    public void ShowOptions()
    {
        anim.SetBool("options", true);
    }

    public void BackToHome()
    {
        anim.SetBool("credits", false);
        anim.SetBool("options", false);
    }
}
