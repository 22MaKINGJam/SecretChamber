using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public void DayPass()
    {
        DataManager.instance.player.day++;
        Debug.Log(DataManager.instance.player.day);
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