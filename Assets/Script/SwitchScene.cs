using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void NewStart()
    {
        //처음부터 새로 시작
        //메인에서 방 화면 이동

        SceneManager.LoadScene("MyRoom");
    }

    public void GameStart()
    {
        //이어하기
        //메인에서 방 화면 이동
        SceneManager.LoadScene("MyRoom");
    }

    public void Back2Main()
    {
        //방 화면에서 메인 이동
       
        SceneManager.LoadScene("Main");
    }

    public void GoAdv()
    {
        //방에서 탐험 화면으로 이동
        SceneManager.LoadScene("DialogTestScene");
        Debug.Log(DataManager.instance.player.day);
    }

    public void Escape()
    {
        // 엔딩 5 : 탈출
        SceneManager.LoadScene("EscapeScene");
    }

    public void DayMark()
    {
        SceneManager.LoadScene("DayMark");
    }
}
