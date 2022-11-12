using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int day =1;
}

public class DataManager : MonoBehaviour
{ 
    //public static DataManager instance;

    PlayerData player = new PlayerData();


    /*private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        /*else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + "/save";
        Debug.Log(path);
        
    }
    */

    public void DayPass()
    {
        player.day++;
        Debug.Log(player.day);
    }

    public void Save()
    {
        //저장, 플레이어 정보 json으로 만들기
        string data = JsonUtility.ToJson(player);
        Debug.Log(data);
        File.WriteAllText(Application.dataPath + "/save", data);
    }

    public void Load()
    {
        if(File.Exists(Application.dataPath + "/save"))
        {
            string data = File.ReadAllText(Application.dataPath + "/save");
            player = JsonUtility.FromJson<PlayerData>(data);
            Debug.Log(data);
            SceneManager.LoadScene("MyRoom");
        }
        else
        {
            Debug.Log("파일 없음");
        }
        
    }

    public void DataClear()
    {
        player = new PlayerData();
    }

}
