using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PlayerData
{
    public int day = 1;
}

public class DataManager : MonoBehaviour
{ 
    public static DataManager instance;

    public PlayerData player = new PlayerData();

    public string path;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + "/save";

        print(path);

    }
    public void DayPass()
    {
        DataManager.instance.player.day++;
        Debug.Log(DataManager.instance.player.day);
    }

    public void DataClear()
    {
        player = new PlayerData();
    }

}
