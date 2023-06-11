using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer1Script : MonoBehaviour
{

    public float timeToFill = 1.0f;
    private Image TimerImage = null;
    public FlyOnBurgerMeat meat;
    public UnityEvent onBarFilled;

    public Coroutine barFillCoroutine = null;
    
    

    private void Start()
    {
        TimerImage = GetComponent<Image>();
        
    }



    public void StartTimer()
    {
        if (barFillCoroutine == null)
        {
            
            barFillCoroutine = StartCoroutine(nameof(FillTimer));
        }
        
    }

    public void StopTimer()
    {
        if(barFillCoroutine != null) 
            StopCoroutine(barFillCoroutine);
        barFillCoroutine= null;
        TimerImage.fillAmount = 0;

    }

    IEnumerator FillTimer()
    {
        
            float startTime = Time.time;
            float overTime = startTime + timeToFill;
            float last = 0;
        

            while (Time.time < overTime)
            {
                last = TimerImage.fillAmount;
                TimerImage.fillAmount = Mathf.Lerp(0, 1, (Time.time - startTime) / timeToFill);

                if (last <= 0.33 && TimerImage.fillAmount > 0.33)
                    meat.ChangeTexture(ImageProgressBarMeat.State);


                if (last <= 0.66 && TimerImage.fillAmount > 0.66)
                    meat.ChangeTexture(ImageProgressBarMeat.State);
                    


                yield return null;
            }

            TimerImage.fillAmount = 0.0f;

            if (onBarFilled != null)
            {
                onBarFilled.Invoke();
                
            }

            barFillCoroutine = null;

    }
}
