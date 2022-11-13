using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
   
    public void DayPass()
    {
        DataManager.instance.player.day++;
        Debug.Log(DataManager.instance.player.day);

    }



    public void End()
    {
        if(DataManager.instance.player.day == 10)
        {
            SceneManager.LoadScene("EscapeScene");
        }
    }

    public void Save()
    {
        DataManager.instance.SaveData();
    }

    public void Load()
    {
        DataManager.instance.LoadData();
    }
}