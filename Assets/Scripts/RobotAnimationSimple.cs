using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimationSimple : MonoBehaviour
{
    float time = 0;
    public bool animate = false;
    Vector3 start_pos, position, finish_pos;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(-5.92f, -0.9f, 2f);
        start_pos = new Vector3(-5.92f, -0.9f, 8f);
        finish_pos = new Vector3(-5.92f, -0.9f, -8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
            FinishAnimation();
        }
        else
        {
            if (transform.position.z == position.z)
                WaitAnimation();
            else
                StartAnimation();
        }
    }

    void StartAnimation() 
    {
        transform.position = Vector3.MoveTowards(transform.position, position, 0.03f);
        if (transform.position.z == position.z)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void WaitAnimation()
    {
        transform.position = new Vector3(transform.position.x, -1 + Mathf.Sin(Time.fixedTime) * 0.5f, transform.position.z);
    }

    void FinishAnimation() 
    {
        if (transform.position.z == position.z)
        {
            transform.Rotate(0, 90, 0);
        }
        transform.position = Vector3.MoveTowards(transform.position, finish_pos, 0.03f);
        if (transform.position.z == finish_pos.z)
        {
            animate = false;
            transform.position = start_pos;
        }
    }
}
