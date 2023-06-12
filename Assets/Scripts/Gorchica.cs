using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorchica : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 0;
    public GameObject plate;
    public float ProductHeight;

    protected int weaponIndex;
    public bool animate = false;
    public Motion motForOverride;
    Animator anim;
    PlateScript plateS;
    public GameObject sousModel;
    public Material sousMaterial;
    public int id;
    // Start is called before the first frame update

    void Start()
    {
        plateS = plate.GetComponent<PlateScript>();
        anim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
            
            anim.SetBool("animate", true);
            animate = false;
        }

    }

    void createObject()
    {
        anim.SetBool("animate", false);

        GameObject clone = Instantiate(sousModel);

        Transform t =clone.GetComponent<Transform>();
        t.position = new Vector3(plate.transform.position.x, plate.transform.position.y + plateS.Height, plate.transform.position.z);

        clone.GetComponent<MeshRenderer>().material = sousMaterial;

        plateS.burger.Add(clone);
        plateS.Ids.Add(id);
    }

    void SemPlate1()
    {
        plateS.ProductAddNow = true;
        plateS.Height += ProductHeight;

    }

    void SemPlate2()
    {

        plateS.ProductAddNow = false;
    }

    public void StartAnimation()
    {
        animate = true;
    }
}
