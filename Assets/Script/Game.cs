using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======
>>>>>>> e8fb6fdfd483dec6d386e2ada7ea9b34cfbc6dbc

public class Game : MonoBehaviour
{
    public void DayPass()
    {
        DataManager.instance.player.day++;
        Debug.Log(DataManager.instance.player.day);
<<<<<<< HEAD

    }

    public void End()
    {
        if(DataManager.instance.player.day == 10)
        {
            SceneManager.LoadScene("EscapeScene");
        }
=======
>>>>>>> e8fb6fdfd483dec6d386e2ada7ea9b34cfbc6dbc
    }

    public void Save()
    {
        DataManager.instance.SaveData();
    }

    public void Load()
    {
        DataManager.instance.LoadData();
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> e8fb6fdfd483dec6d386e2ada7ea9b34cfbc6dbc
