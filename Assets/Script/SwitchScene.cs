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

    public void Back2Main()
    {
        //방 화면에서 메인 이동
        SceneManager.LoadScene("Main");
    }
}
