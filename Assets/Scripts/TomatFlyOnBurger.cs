using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class TomatFlyOnBurger : MonoBehaviour
{
    float time = 0;
    public GameObject plate;
    public float ProductHeight;

    protected int weaponIndex;
    public bool animate = false;
    Vector3 start;
    public Motion motForOverride;
    Animator anim;
    PlateScript plateS;
    AnimatorOverrideController overrideController;
    public int id;
    // Start is called before the first frame update

    void Start()
    {
        start = transform.position;
        plateS = plate.GetComponent<PlateScript>();
        anim = GetComponent<Animator>();
        overrideController = new AnimatorOverrideController();
        overrideController.runtimeAnimatorController = anim.runtimeAnimatorController;
        UpdateAnimation();

    }

    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
            UpdateAnimation();
            anim.SetBool("Fly", true);
            animate = false;
        }

    }

    // Update is called once per frame
    
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
        transY.AddKey(1.5f, Math.Max(start.y + 1f, plate.transform.position.y + plateS.Height + 0.016f) + 1);
        transY.AddKey(2.5f, plate.transform.position.y + 0.016f + plateS.Height);

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

        AnimationEvent CloneEvent = new AnimationEvent();
        CloneEvent.time = 2.5f;
        CloneEvent.functionName = "cloneObject";

        AnimationEvent BoolEvent = new AnimationEvent();
        BoolEvent.time = 0.0f;
        BoolEvent.functionName = "SemPlate";

        AnimationClip clip = new AnimationClip();
        clip.SetCurve("", typeof(Transform), "localPosition.x", transX);
        clip.SetCurve("", typeof(Transform), "localPosition.y", transY);
        clip.SetCurve("", typeof(Transform), "localPosition.z", transZ);
        clip.SetCurve("", typeof(Transform), "localRotation.x", rotationX);
        clip.SetCurve("", typeof(Transform), "localRotation.y", rotationY);
        clip.AddEvent(CloneEvent);
        clip.AddEvent(BoolEvent);

        
        overrideController[motForOverride.name] = clip;
        anim.runtimeAnimatorController = overrideController;
    }

    void cloneObject()
    {
        anim.SetBool("Fly", false);

        GameObject clone = Instantiate(this.gameObject);
        Destroy(clone.GetComponent<TomatFlyOnBurger>());

        plateS.ProductAddNow = false;
        plateS.burger.Add(clone);
        plateS.Ids.Add(id);


    }

    void SemPlate()
    {
        plateS.ProductAddNow = true;
        plateS.Height += ProductHeight;
        this.GetComponent<AudioSource>().mute = false;
        this.GetComponent<AudioSource>().Play();

    }

    public void StartAnimation()
    {
        animate = true;
    }
}
