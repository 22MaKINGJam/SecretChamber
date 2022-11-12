using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RadialProgress : MonoBehaviour
{
   
    public Image LoadingBar;
    float maxHealth = 100f;
    public static float health;

    // Start is called before the first frame update
    void Start()
    {
        LoadingBar = GetComponent<Image>();
        health = maxHealth;
    }
        
    void Update()
    {
        LoadingBar.fillAmount = health / maxHealth;
    }
}