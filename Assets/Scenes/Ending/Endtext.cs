using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Endtext : MonoBehaviour
{
    // #1

    public GameObject boxDialog;    // 게임오브젝트 : 대화창
    public GameObject boxName;      // 게임오브젝트 : 이름창
    public TMP_Text dialogText;         // 텍스트 : 대화창 내부 
    public TMP_Text nameText;           // 텍스트 : 이름창 내부
    public bool isAction;           // 대화창/이름창 활성화 여부
    public bool isAction_boxName;   // 이름창 활성화 여부
    public int talkIndex;           // 진행 중인 대화 인덱스

    public int scene_id = 0;

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

            SceneManager.LoadScene("Main");

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
        // 엔딩5
        Dictionary<int, string[]> talkData = new Dictionary<int, string[]>();

       
        talkData.Add(0, new string[] { "", "이번 화재로 건물이 전소되었으나 인명 피해는 없는 것으로 밝혀졌는데요." });
        talkData.Add(1, new string[] { "", "연구소 측은 정기 점검을 실시했기 때문에 외부의 방화범이 고의적으로 방화한 것으로 \n\n추정된다고 발표했습니다." });
        talkData.Add(2, new string[] { "", "한편, 화재 당시 불 속에서 걸어 나오는 사람을 봤다는 제보가 계속해서 들어오면서 \n\n사고에 대한 관심이 커지고 있습니다." });
        talkData.Add(3, new string[] { "괴물", "…조금만 기다려 혜린. 내가 갈테니까." });
        talkData.Add(4, new string[] { "괴물", "나를 왜 이렇게 만들었는지. 네게 들어야 하는 말이 많아 나는." });


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
