using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialDig : MonoBehaviour
{
    // #1

    public GameObject boxDialog;    // 게임오브젝트 : 대화창
    public GameObject boxName;      // 게임오브젝트 : 이름창
    public TMP_Text dialogText;         // 텍스트 : 대화창 내부 
    public TMP_Text nameText;           // 텍스트 : 이름창 내부
    public bool isAction;           // 대화창/이름창 활성화 여부
    public bool isAction_boxName;   // 이름창 활성화 여부
    public int talkIndex;           // 진행 중인 대화 인덱스

    public int scene_id = 1;

    List<Dictionary<int, string[]>> dialogList;

    void Awake()
    {
        dialogList = new List<Dictionary<int, string[]>>();

        GenerateData();
        talkIndex = 0;
    }

    void Update()
    {
    }

    public void Talk()
    {

        string talkData = GetTalk(scene_id, talkIndex);
        string speakerData = GetSpeaker(scene_id, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            boxDialog.SetActive(false); // 대화창 비활성화
            boxName.SetActive(false);   // 이름창 비활성화

            dialogText.text = "";
            nameText.text = "";
            talkIndex = 0;
            return;
        }

        if (speakerData == "쪽지" | speakerData == "")
        {
            isAction_boxName = false;
            boxName.SetActive(isAction_boxName);    // 이름창 비활성화
            nameText.text = "";
        }
        else
        {
            isAction_boxName = true;
            boxName.SetActive(isAction_boxName);    // 이름창 활성화
            nameText.text = speakerData;    // 이름창 대화
        }

        dialogText.text = talkData;     // 대화창 대화

        // isAction = true;
        talkIndex++;
    }

    void GenerateData()
    {
        // #0 튜토리얼
        Dictionary<int, string[]> talkData = new Dictionary<int, string[]>();

        talkData.Add(0, new string[] { "나", "… 여긴 어디지…?" });
        talkData.Add(1, new string[] { "나", "…" });
        talkData.Add(2, new string[] { "나", "내가 이곳에 얼마나 오래 있었던 건지 잘 모르겠다." });
        talkData.Add(3, new string[] { "나", "…" });
        talkData.Add(4, new string[] { "나", "나는 누구지…?" });
        talkData.Add(5, new string[] { "나", "…" });
        talkData.Add(6, new string[] { "?", "문이 보인다. 나갈 수 있는 건가." });

        dialogList.Add(talkData);
    }

    public string GetSpeaker(int scence_id, int id)
    {
        if (id >= dialogList[scene_id].Count)
            return null;
        return dialogList[scene_id][id][0];
    }

    public string GetTalk(int scence_id, int id)
    {
        if (id >= dialogList[scene_id].Count)
            return null;
        return dialogList[scene_id][id][1];
    }
}
