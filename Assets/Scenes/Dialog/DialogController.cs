using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    // #1

    public GameObject boxDialog;    // 대화창
    public Text dialogText;         // 대화창 내부 텍스트
    public bool isAction;           // 활성화 여부
    public int talkIndex;           // 진행 중인 대화 인덱스

    Dictionary<int, string[]> talkData;

    void Awake() {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
        talkIndex = 0;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            string talkData = GetTalk(talkIndex);

            if (talkData == null) {
                isAction = false;
                boxDialog.SetActive(false);
                dialogText.text = "";
                talkIndex = 0;
                return;
            }

            dialogText.text = talkData;
            // isAction = true;
            talkIndex++;
        }
    }

    void GenerateData()
    {
        talkData.Add(0, new string[] { "(우당탕탕탕!)"});
        talkData.Add(1, new string[] { "(헉. 너무 큰 소리를 냈나? 어두워서 아무것도 보이지 않는다. 여긴 어디지?)"});
        talkData.Add(2, new string[] { "누구세요?"});
        talkData.Add(3, new string[] { "(이런. 역시 소리가 너무 컸다. 누구지? 누군가 나를 향해 다가온다.)"});
    }

    public string GetTalk(int id)
    {
        if (id>=talkData.Count)
            return null;
        return talkData[id][0];
    }
}
