using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlyOnBurgerMeat : MonoBehaviour
{
    // Start is called before the first frame update
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
    public Material[] materials;
    int NextMaterial = 1;
    // Start is called before the first frame update

    void Start()
    {
        this.GetComponent<Renderer>().material = materials[0];
        start = new Vector3(0.691f,-2.448f,-2.753f);
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
            anim.SetBool("animate", true);
            animate = false;
        }

    }



    void UpdateAnimation()
    {
        AnimationCurve transX = new AnimationCurve();
        transX.AddKey(0.0f, start.x);
        transX.AddKey(1.0f, (start.x + plate.transform.position.x) / 2);
        transX.AddKey(2.0f, plate.transform.position.x);

        AnimationCurve transY = new AnimationCurve();
        transY.AddKey(0.0f, start.y);
        transY.AddKey(1.0f, Math.Max(start.y, plate.transform.position.y + plateS.Height + 0.016f) + 1);
        transY.AddKey(2.0f, plate.transform.position.y + 0.016f + ProductHeight + plateS.Height);

        AnimationCurve transZ = new AnimationCurve();
        transZ.AddKey(0.0f, start.z);
        transZ.AddKey(1.0f, (start.z + plate.transform.position.z) / 2);
        transZ.AddKey(2.0f, plate.transform.position.z);

        AnimationEvent CloneEvent = new AnimationEvent();
        CloneEvent.time = 2.0f;
        CloneEvent.functionName = "cloneObject";

        AnimationEvent BoolEvent = new AnimationEvent();
        BoolEvent.time = 0.0f;
        BoolEvent.functionName = "SemPlate";

        

        AnimationClip clip = new AnimationClip();
        clip.SetCurve("", typeof(Transform), "localPosition.x", transX);
        clip.SetCurve("", typeof(Transform), "localPosition.y", transY);
        clip.SetCurve("", typeof(Transform), "localPosition.z", transZ);
        clip.AddEvent(CloneEvent);
        clip.AddEvent(BoolEvent);
        



        overrideController[motForOverride.name] = clip;
        anim.runtimeAnimatorController = overrideController;
    }

    void cloneObject()
    {
        anim.SetBool("animate", false);

        GameObject clone = Instantiate(this.gameObject);
        Destroy(clone.GetComponent<FlyOnBurgerMeat>());
        Destroy(clone.GetComponent<Animator>());

        plateS.ProductAddNow = false;
        


    }

    void SemPlate()
    {
        plateS.ProductAddNow = true;
        plateS.Height += ProductHeight;
        ChangeTexture();
    }

    public void StartAnimation()
    {
        animate = true;
    }

    public void StartAnimate()
    {
        anim.SetBool("animate", true);
    }

    public void StartAnimate2()
    {
        anim.SetBool("animate2", true);
    }

    public void StartAnimate3()
    {
        anim.SetBool("animate3", true);
    }

    public void StopAnimate()
    {
        anim.SetBool("animate", false);
        anim.SetBool("animate2", false);
        anim.SetBool("animate3", false);
    }

    public void ChangeTexture()
    {
        
        this.GetComponent<Renderer>().material = materials[ NextMaterial++ ];

        if (NextMaterial > 2) NextMaterial = 0;
    }
}
