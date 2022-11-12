using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayMark : MonoBehaviour
{
    public Image d1;
    public Image d2;

    public void Awake()
    {
        SceneManager.LoadScene("DayMark");
        
        if (DataManager.instance.player.day == 2)
        {
            d1.gameObject.SetActive(true);
        }

        if(DataManager.instance.player.day == 3)
        {
            d2.gameObject.SetActive(true);
        }
    }
}
