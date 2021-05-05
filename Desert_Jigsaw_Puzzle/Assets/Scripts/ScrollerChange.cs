using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerChange : MonoBehaviour
{
    public Slider slider;
    private Animation anim;

    public void Start()
    {
        
        anim = GetComponent<Animation>();
        anim.Play("CamelBending");
        anim["CamelBending"].speed = 0;
       
    }
    public void Update()
    {
        anim["CamelBending"].normalizedTime = slider.value;
    }

}
