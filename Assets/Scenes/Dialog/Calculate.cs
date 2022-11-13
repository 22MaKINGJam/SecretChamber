using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculate : MonoBehaviour
{
    public static Calculate instance;
    public GameObject healthObj, selfObj, smartObj;
    public Image healthBar, selfBar, smartBar;
    public static int healthV, selfV, smartV;

    // Start is called before the first frame update
    void Awake()
    {   
        healthV = 100;
        selfV = 0;
        smartV = 10;

        healthBar = healthObj.GetComponent<Image>();
        selfBar = selfObj.GetComponent<Image>();
        smartBar = smartObj.GetComponent<Image>();
    }

    public void SetHealthBar(int value){
        healthV += value;
        healthBar.fillAmount = (float) healthV / 100f;
    }

    public void SetSelfBar(int value){
        selfV += value;
        selfBar.fillAmount = (float) selfV / 100f;
    }

    public void SetSmartBar(int value){
        smartV += value;
        smartBar.fillAmount = (float) smartV / 100f;
    }
}
