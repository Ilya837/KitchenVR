using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Animator)) ]

public class FlyOnBurgerAnimation : MonoBehaviour
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
    public bool isEndEngredient = false;
    public RobotAnimation robot;
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
            animate= false;
        }
        
    }

    

    void UpdateAnimation()
    {
        AnimationCurve transX = new AnimationCurve();
        transX.AddKey(0.0f, start.x);
        transX.AddKey(1.0f,(start.x + plate.transform.position.x)/2);
        transX.AddKey(2.0f, plate.transform.position.x);

        AnimationCurve transY = new AnimationCurve();
        transY.AddKey(0.0f, start.y);
        transY.AddKey(1.0f, Math.Max(start.y, plate.transform.position.y + plateS.Height + 0.016f) + 1);
        transY.AddKey(2.0f, plate.transform.position.y + 0.016f + plateS.Height);

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
        anim.SetBool("Fly", false);

        GameObject clone = Instantiate(this.gameObject);
        Destroy(clone.GetComponent<FlyOnBurgerAnimation>());

        
        

        plateS.ProductAddNow = false;
        plateS.burger.Add(clone);
        plateS.Ids.Add(id);

        if (isEndEngredient)
        {
            robot.Startanim(1);

        }
        
    }

    void SemPlate()
    {
        plateS.ProductAddNow = true;
        plateS.Height += ProductHeight;
        this.GetComponent<AudioSource>().mute= false;
        this.GetComponent<AudioSource>().Play();
        
    }

   public void StartAnimation()
    {
        animate = true;
    }
}
