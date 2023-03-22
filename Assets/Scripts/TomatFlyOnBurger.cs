using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatFlyOnBurger : MonoBehaviour
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
        transX.AddKey(0.5f, start.x);
        transX.AddKey(1.5f, (start.x + plate.transform.position.x) / 2);
        transX.AddKey(2.5f, plate.transform.position.x);

        AnimationCurve transY = new AnimationCurve();
        transY.AddKey(0.0f, start.y);
        transY.AddKey(0.5f, start.y + 1f);
        transY.AddKey(1.5f, Math.Max(start.y + 1f, plate.transform.position.y + BurgerHeight + 0.016f) + 1);
        transY.AddKey(2.5f, plate.transform.position.y + 0.016f + BurgerHeight);

        AnimationCurve transZ = new AnimationCurve();
        transZ.AddKey(0.0f, start.z);
        transZ.AddKey(0.5f, start.z);
        transZ.AddKey(1.5f, (start.z + plate.transform.position.z) / 2);
        transZ.AddKey(2.5f, plate.transform.position.z);

        AnimationCurve rotationX = new AnimationCurve();
        rotationX.AddKey(0.0f, 90.0f);
        rotationX.AddKey(0.5f, 90.0f);
        rotationX.AddKey(1.5f, 90.0f);
        rotationX.AddKey(2.5f, 0.0f);

        AnimationCurve rotationY = new AnimationCurve();
        rotationY.AddKey(0.0f, 90);

        AnimationClip clip = new AnimationClip();
        clip.SetCurve("", typeof(Transform), "localPosition.x", transX);
        clip.SetCurve("", typeof(Transform), "localPosition.y", transY);
        clip.SetCurve("", typeof(Transform), "localPosition.z", transZ);
        clip.SetCurve("", typeof(Transform), "localRotation.x", rotationX);
        clip.SetCurve("", typeof(Transform), "localRotation.y", rotationY);

        AnimatorOverrideController overrideController = new AnimatorOverrideController();
        overrideController.runtimeAnimatorController = anim.runtimeAnimatorController;
        overrideController[motForOverride.name] = clip;
        anim.runtimeAnimatorController = overrideController;
    }

    
}
