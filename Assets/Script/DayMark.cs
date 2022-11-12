using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayMark : MonoBehaviour
{

    public Image d1;
    public Image d2;
    public Image d3;
    public Image d4;
    public Image d5;
    public Image d6;
    public Image d7;
    public Image d8;


    // Start is called before the first frame update

    public void SwitchScene()
    {
        SceneManager.LoadScene("MyRoom");
    }
    void Start()
    {
        if(DataManager.instance.player.day == 2)
        {
            d1.gameObject.SetActive(true);
            
        }

        else if(DataManager.instance.player.day == 3)
        {
            d2.gameObject.SetActive(true);
            
        }

        else if (DataManager.instance.player.day == 4)
        {
            d3.gameObject.SetActive(true);

        }

        else if (DataManager.instance.player.day == 5)
        {
            d4.gameObject.SetActive(true);

        }

        else if (DataManager.instance.player.day == 6)
        {
            d5.gameObject.SetActive(true);

        }

        else if (DataManager.instance.player.day == 7)
        {
            d6.gameObject.SetActive(true);

        }

        else if (DataManager.instance.player.day == 8)
        {
            d7.gameObject.SetActive(true);

        }

        else if(DataManager.instance.player.day == 9)
        {
            d8.gameObject.SetActive(true);
        }
    }

}
