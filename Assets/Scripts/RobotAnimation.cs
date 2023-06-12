using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimation : MonoBehaviour
{
    float time = 0;
    //public GameObject plate;

    protected int weaponIndex;
    public bool animate = false;
    Vector3 start_pos, position, finish_pos;
    //public Motion motForOverride;
    Animator anim;
    //PlateScript plateS;
    //AnimatorController overrideController;

    // Start is called before the first frame update
    void Start()
    {
        //position = new Vector3(-5.92f, -0.9f, 2f);
        start_pos = new Vector3(-5.92f, -0.7f, 8.14f);
        //finish_pos = new Vector3( -5.92f, -0.9f, -7f);
        anim = GetComponent<Animator>();
        //Controller = new AnimatorController();
        //overrideController.runtimeAnimatorController = anim.runtimeAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
            anim.SetBool("finish", true);
            animate = false;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(("RobotStart")))
        {
            anim.SetBool("finish", false);
        }
    }

    void Reset()
    {
        Debug.Log("Я тут был");
        transform.Translate(-5.92f, -0.7f, 8.14f);
    }

    public void Startanim()
    {
        animate = true;
    }
}
