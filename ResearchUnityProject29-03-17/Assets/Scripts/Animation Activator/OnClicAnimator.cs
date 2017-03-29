using UnityEngine;
using System.Collections;

public class OnClicAnimator : MonoBehaviour {

    public Animator animator;

    private bool Clicked;

    void OnMouseDown()
    {
        animator.SetBool("IsOpen", Clicked);
        if (!Clicked)
        {
            Clicked = true;
        }
        else
        {
            Clicked = false;
        }
    }
}
