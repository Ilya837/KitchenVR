using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FlyOnBurgerAnimation : MonoBehaviour
{

    float time = 0;
    public GameObject plate;

    protected int weaponIndex;
    public bool animate = false;
    float BurgerHeight = 0;
    Vector3 start;
    public Motion motForOverride;
    Animator anim;
    // Start is called before the first frame update

    void Start()
    {
        start = transform.position;
        anim = GetComponent<Animator>();
        UpdateAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Fly", animate);


    }

    void UpdateAnimation()
    {
        AnimationCurve transX = new AnimationCurve();
        transX.AddKey(0.0f, start.x);
        transX.AddKey(1.0f,(start.x + plate.transform.position.x)/2);
        transX.AddKey(2.0f, plate.transform.position.x);

        AnimationCurve transY = new AnimationCurve();
        transY.AddKey(0.0f, start.y);
        transY.AddKey(1.0f, Math.Max(start.y, plate.transform.position.y + BurgerHeight + 0.016f) + 1);
        transY.AddKey(2.0f, plate.transform.position.y + 0.016f + BurgerHeight);

        AnimationCurve transZ = new AnimationCurve();
        transZ.AddKey(0.0f, start.z);
        transZ.AddKey(1.0f, (start.z + plate.transform.position.z) / 2);
        transZ.AddKey(2.0f, plate.transform.position.z);

        AnimationClip clip = new AnimationClip();
        clip.SetCurve("", typeof(Transform), "localPosition.x", transX);
        clip.SetCurve("", typeof(Transform), "localPosition.y", transY);
        clip.SetCurve("", typeof(Transform), "localPosition.z", transZ);

         
        AnimatorOverrideController overrideController = new AnimatorOverrideController();
        overrideController.runtimeAnimatorController = anim.runtimeAnimatorController;
        overrideController[motForOverride.name] = clip;
        anim.runtimeAnimatorController = overrideController;
    }

    
}
