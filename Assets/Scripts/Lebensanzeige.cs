using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lebensanzeige : MonoBehaviour{
    
    public Slider slider;

    public void SetzeMaxLeben(int leben){
        slider.maxValue = leben;
        slider.value = leben;
    }

    public void SetzeLeben(int leben){
        slider.value = leben;
    }
    
}
