using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss_UI : MonoBehaviour
{
     public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHeath(int heath){
        slider.maxValue =heath;
        slider.value =heath;  
        fill.color= gradient.Evaluate(1f);
    }
    public void SetHeath(int heath){
        slider.value =heath;
        fill.color =gradient.Evaluate(slider.normalizedValue);
    }
    private void Update() {
        fill.color =gradient.Evaluate(slider.normalizedValue);
        fill.color= gradient.Evaluate(1f);

    }
}
