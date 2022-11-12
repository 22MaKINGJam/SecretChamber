using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSelf : MonoBehaviour
{

    Image SelfBar;
    float MaxSelf = 100f;
    public static float Self;

    // Start is called before the first frame update
    void Start()
    {
        SelfBar = GetComponent<Image>();
        Self = 80f;
        //여기에 새 변수 저장
    }

    void Update()
    {
        SelfBar.fillAmount = Self / MaxSelf;
    }
}
