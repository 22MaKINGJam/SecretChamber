using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalH : MonoBehaviour
{


    Image HealthBar;
    public static float maxHealth = 100f;
    public static float health = 100f;
    public static float calH = 0f;

    void Start()
    {
        calH = -10f; //각 장면마다 받아야 할 변수
        Cal(calH);
    }

    void Cal(float calH)
    {
        health += calH;
        HealthBar = GetComponent<Image>();
        HealthBar.fillAmount = health / maxHealth;
    }

}