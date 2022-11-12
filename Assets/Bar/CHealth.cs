using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHealth : MonoBehaviour
{

    Image HealthBar;
    float MaxHealth = 100f;
    public static float Health;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        Health = 80f;
        //여기에 새 변수 저장
    }

    void Update()
    {
        HealthBar.fillAmount = Health / MaxHealth;
    }
}
