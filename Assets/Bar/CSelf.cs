using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSelf : MonoBehaviour
{


    Image SelfBar;
    public static float maxSelf = 100f;
    public static float self = 0f;
    public static float calSE = 0f;

    void Start()
    {
        calSE = 10f; //각 장면마다 받아야 할 변수
        Cal(calSE);
    }

    void Cal(float calSE)
    {
        self += calSE;
        SelfBar = GetComponent<Image>();
        SelfBar.fillAmount = self / maxSelf;
    }

}