using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CSmart : MonoBehaviour
{
    Image SmartBar;

    public static float MaxSmart = 100f;
    public static float smart = 10f;
    public static float CalS = 0f;


    void Start()
    {
        CalS = 20f;
        Re(CalS);

    }
    void Re(float CalS)
    {
        SmartBar = GetComponent<Image>();
        smart += CalS;//30
        SmartBar.fillAmount = smart / MaxSmart;
    }

}