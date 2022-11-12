using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    // #1

    public GameObject boxDialog;    // 게임오브젝트 : 대화창
    public GameObject boxName;      // 게임오브젝트 : 이름창
    public TMP_Text dialogText;         // 텍스트 : 대화창 내부 
    public TMP_Text nameText;           // 텍스트 : 이름창 내부
    public bool isAction;           // 대화창/이름창 활성화 여부
    public int talkIndex;           // 진행 중인 대화 인덱스

    Dictionary<int, string[]> talkData;

    void Awake() {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
        talkIndex = 0;
    }

    void Update() {
    }

    public void Talk(){
        string talkData = GetTalk(talkIndex);
        string speakerData = GetSpeaker(talkIndex);

        if (talkData == null) {
            isAction = false;
            boxDialog.SetActive(false); // 대화창 비활성화
            boxName.SetActive(false);   // 이름창 비활성화

            dialogText.text = "";
            nameText.text = "";
            talkIndex = 0;
            return;
        }

        dialogText.text = talkData;     // 대화창 대화
        nameText.text = speakerData;    // 이름창 대화

        // isAction = true;
        talkIndex++;
    }

    void GenerateData()
    {
        // # 1 대사

        talkData.Add(0, new string[] { "","(우당탕탕탕!)"});
        talkData.Add(1, new string[] { "나","(헉. 너무 큰 소리를 냈나? 어두워서 아무것도 보이지 않는다. 여긴 어디지?)"});
        talkData.Add(2, new string[] { "?","누구세요?"});
        talkData.Add(3, new string[] { "나","(이런. 역시 소리가 너무 컸다. 누구지? 누군가 나를 향해 다가온다.)"});
        talkData.Add(4, new string[] { "?","누구세요? 아니.. 여기서 뭘 하고 계시는 거예요?"});
        talkData.Add(5, new string[] { "나","…"});
        talkData.Add(6, new string[] { "?","… 너 말을 못하니?"});
        talkData.Add(7, new string[] { "나","(말…? 아니야. 할 수 있어. 그런데.. 생각하다보니 목소리를 어떻게 냈었는지 모르겠다. 혼란스러워.)"});
        talkData.Add(8, new string[] { "?","괜찮아. 내 말에 고개를 끄덕이기만 하면 돼. 이건 할 수 있지?"});
        talkData.Add(9, new string[] { "나","(끄덕)"});
        talkData.Add(10, new string[] { "혜린","내 이름은 전혜린이야. 109호에 살고 있어. 너는.. B158에 사는 것 같네. 아무튼 반가워!"});
        talkData.Add(11, new string[] { "나","(혜린이 손을 내밀었다. 잡으라는 건가? 우선 잡아봐야지.)"});
        talkData.Add(12, new string[] { "혜린","또래 친구가 없어서 심심했는데. 잘됐다! 앞으로 자주 보자. 내일 또 봐!"});
        talkData.Add(13, new string[] { "나","(친구…? 친구… 친구… 어딘가 간지러운 기분이다. 내일 또 볼 수 있을까?)"});
    }

    public string GetSpeaker(int id)
    {
        if (id>=talkData.Count)
            return null;
        return talkData[id][0];
    }

    public string GetTalk(int id)
    {
        if (id>=talkData.Count)
            return null;
        return talkData[id][1];
    }
}
