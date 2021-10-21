using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : Timer
{
    private Slider slider;
    private void Awake()
    {
        slider = FindObjectOfType<Slider>();


    }

    private void Start()
    {
       slider.maxValue = tempo;
        
    }

    // Update is called once per frame
    void Update()
    {
       slider.maxValue =tempo;
        
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
               slider.value += Time.deltaTime;
                
            }
            else
            {

                slider.value = slider.maxValue;
            }
        }
    }

}
