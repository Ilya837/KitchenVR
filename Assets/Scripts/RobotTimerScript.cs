using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RobotTimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeToFill = 1.0f;
    public UnityEvent onBarFilled;

    public Coroutine barFillCoroutine = null;
    float time1;
    public Material[] materials= null;
    public PlateScript plate;
    public int MaterialNow = 0;



    public void StartTimer()
    {
        if (barFillCoroutine == null)
        {

            barFillCoroutine = StartCoroutine(nameof(FillTimer));
        }

    }

    public void StopTimer()
    {
        if (barFillCoroutine != null)
            StopCoroutine(barFillCoroutine);
        time1 = 0;

        plate.BurgerEnd();
        barFillCoroutine = null;

    }

    IEnumerator FillTimer()
    {

        float startTime = Time.time;
        float overTime = startTime + timeToFill;
        float last = 0;


        while (Time.time < overTime)
        {
            last = time1;
            time1 = Mathf.Lerp(0, 1, (Time.time - startTime) / timeToFill);

            if (last <= 0.33 && time1 > 0.33)
                SetMaterial(1);


            if (last <= 0.66 && time1 > 0.66)
                SetMaterial(2);



            yield return null;
        }

        time1 = 0.0f;

        if (onBarFilled != null)
        {
            onBarFilled.Invoke();
            

        }

        barFillCoroutine = null;

    }

    public void SetMaterial(int materialIndex)
    {
        MaterialNow = materialIndex;
        this.GetComponent<Renderer>().material = materials[materialIndex];
    }

}
