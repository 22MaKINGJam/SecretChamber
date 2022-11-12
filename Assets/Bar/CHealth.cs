using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CHealth : MonoBehaviour
{
    Image HealthBar;
   
    public static float MaxHealth = 100f;
    public static float health = 100f;
    public static float CalH = 0f;


    void Start()
    {
        CalH = -10f;
        Re(CalH);
       
    }
    void Re(float CalH)
    {
        HealthBar = GetComponent<Image>();
        health += CalH;//90
        HealthBar.fillAmount = health / MaxHealth;
    }


  
}