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
    public int day = 1;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public PlayerData player = new PlayerData();

    public string path;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        /*else if (instance != this)
        {
            Destroy(instance.gameObject);
        }*/

        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + "/save";
        Debug.Log(path);

    }


    public void SaveData()
    {
        //저장, 플레이어 정보 json으로 만들기
        string data = JsonUtility.ToJson(player);
        File.WriteAllText(Application.dataPath + "/save", data);
        Debug.Log(data);
    }

    public void LoadData()
    {
        if (File.Exists(Application.dataPath + "/save"))
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