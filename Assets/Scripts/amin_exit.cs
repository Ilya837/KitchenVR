using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class amin_exit : MonoBehaviour
{
    public Animator animator;
    public Button button;

    void Start()
    {
        button = GetComponent<Button>();
        animator = GetComponent<Animator>();
    }

    public void OnButtonEnter()
    {
        animator.SetTrigger("Highlighted");

    }

    public void OnButtonExit()
    {

        animator.SetTrigger("Normal");
    }
}
