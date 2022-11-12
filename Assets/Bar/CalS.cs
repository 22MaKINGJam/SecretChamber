using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalS : MonoBehaviour
{


    Image SmartBar;
    public static float maxSmart = 100f;
    public static float smart = 10f;
    public static float calS = 0f;

    void Start()
    {
        calS = 40f; //각 장면마다 받아야 할 변수
        Cal(calS);
    }

    void Cal(float calS)
    {
        smart += calS;
        SmartBar = GetComponent<Image>();
        SmartBar.fillAmount = smart / maxSmart;
    }

}