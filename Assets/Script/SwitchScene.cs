using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void GameStart()
    {
        //메인에서 방 화면 이동
        SceneManager.LoadScene("MyRoom");
    }
}
