using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CSelf : MonoBehaviour
{
    Image SelfBar;
    public static float MaxSelf = 100f;
    public static float self = 0f;
    public static float CalSe = 0f;


    void Start()
    {
        CalSe = 30f;
        Re(CalSe);

    }
    void Re(float CalSe)
    {
        SelfBar = GetComponent<Image>();
        self += CalSe;//30
        SelfBar.fillAmount = self / MaxSelf;
    }

}