using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CSmart : MonoBehaviour
{

    Image SmartBar;
    float MaxSmart = 100f;
    public static float Smart;

    // Start is called before the first frame update
    void Start()
    {
        SmartBar = GetComponent<Image>();
        Smart = 80f;
        //여기에 새 변수 저장
    }

    void Update()
    {
        SmartBar.fillAmount = Smart / MaxSmart;
    }
}
