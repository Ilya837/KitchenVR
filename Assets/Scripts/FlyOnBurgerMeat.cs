using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlyOnBurgerMeat : MonoBehaviour
{
    // Start is called before the first frame update
    
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
    private int MaterialNumber;
    public int id;

    public Timer1Script timer;
    // Start is called before the first frame update

    void Start()
    {
        this.GetComponent<Renderer>().material = materials[0];
        start = new Vector3(0.691f,-2.448f,-2.753f);
        plateS = plate.GetComponent<PlateScript>();
        anim = GetComponent<Animator>();
        overrideController = new AnimatorOverrideController();
        overrideController.runtimeAnimatorController = anim.runtimeAnimatorController;
        MaterialNumber = 0;
        UpdateAnimation();

    }

    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
            UpdateAnimation();
            anim.SetTrigger("Animate");
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

        GameObject clone = Instantiate(this.gameObject);
        Destroy(clone.GetComponent<FlyOnBurgerMeat>());
        Destroy(clone.GetComponent<Animator>());

        plateS.ProductAddNow = false;

        plateS.burger.Add(clone);
        plateS.Ids.Add(id);



    }

    void SemPlate()
    {
        plateS.ProductAddNow = true;
        plateS.Height += ProductHeight;
        timer.StopTimer();
    }

    public void StartAnimation()
    {
        animate = true;
    }

    public void StartAnimate()
    {
        anim.SetTrigger("Animate");
    }

    

    public void ChangeTexture(int StageNum)
    {

        switch (StageNum)
        {
                case 1:
                {
                    MaterialNumber++;
                    break;
                }
                case 2:
                {
                    if (MaterialNumber < 3)
                    {
                        MaterialNumber *= 2;
                    }
                        
                    MaterialNumber+=1;
                    break;
                }
                case 3:
                {
                    MaterialNumber = 0;
                    break;
                }
        }

        this.GetComponent<Renderer>().material = materials[MaterialNumber];
    }

    public void StartTimer()
    {
        timer.StartTimer();
    }

    public void StopTimer()
    {
        timer.StopTimer();
    }

    public void End()
    {
        anim.SetTrigger("End");

        ChangeTexture(3);

    }
}
