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
    public bool isAction_boxName;   // 이름창 활성화 여부
    public int talkIndex;           // 진행 중인 대화 인덱스

    public int scene_id = 1;

    List<Dictionary<int, string[]>> dialogList;

    void Awake() {
        dialogList = new List<Dictionary<int, string[]>>();
        
        GenerateData();
        talkIndex = 0;
    }

    void Update() {
    }

    public void Talk(){
        string talkData = GetTalk(scene_id, talkIndex);
        string speakerData = GetSpeaker(scene_id, talkIndex);

        if (talkData == null) {
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
        else {
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
        // # 1 대사
        Dictionary<int, string[]> talkData = new Dictionary<int, string[]>();

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

        dialogList.Add(talkData);

        // # 2 대사

        Dictionary<int, string[]> talkData2 = new Dictionary<int, string[]>();

        talkData2.Add(0, new string[] { "","(문 앞에 쪽지가 떨어져있다.)"});
        talkData2.Add(1, new string[] { "쪽지","안녕 친구! 만약 오늘도 날 만나고 싶다면 도서관으로 와! 복도 끝에서 오른쪽 계단을 올라와서 첫 번째 문을 열면 돼. 기다릴게! \n\n -혜린"});
        talkData2.Add(2, new string[] { "나","(… 할일도 없는데 한번 가볼까.)"});
        talkData2.Add(3, new string[] { "","(도서관의 문을 열고 들어간다.)"});
        talkData2.Add(4, new string[] { "","(끼이이이익-)"});
        talkData2.Add(5, new string[] { "혜린","왔구나! 와줄 거라고 생각했어. 어서와!"});
        talkData2.Add(6, new string[] { "나","(도서관… 책이 많다… 이런 곳도 있구나…)"});
        talkData2.Add(7, new string[] { "혜린","자 여기 앉아봐. 이제 우리는 재밌는 걸 할 거야."});
        talkData2.Add(8, new string[] { "나","(끄덕)"});
        talkData2.Add(9, new string[] { "혜린","내가 이제 매일 숙제를 내줄거야. 너는 잘 따라오기만 하면 돼. 우선 오늘은 말하기랑 수학. 같이 글을 읽어보자. 글은 읽을 수 있지?"});
        talkData2.Add(10, new string[] { "나","(….?)"});
        talkData2.Add(11, new string[] { "혜린","글은 읽을 수 있냐니까?"});
        talkData2.Add(12, new string[] { "나","(고개를 가로젓는다.)"});
        talkData2.Add(13, new string[] { "혜린","갈 길이 머네. 자 그럼 날 따라해봐. 이건 아-라고 읽는거야. 소리내봐. 아-"});
        talkData2.Add(14, new string[] { "나","….아-"});
        talkData2.Add(15, new string[] { "혜린","잘했어!! 이건 어-라고 읽는건데…."});
        talkData2.Add(16, new string[] { "나","(끙… 이제 매일 공부를 해야 되는 건가…)"});
        // talkData.Add(17, new string[] { "나","(복도가 온통 구구단 쪽지로 가득하다. 이걸 대체 왜 배워야하는 건지...)"});
        // talkData.Add(18, new string[] { "혜린","7 X 9?"});
        // talkData.Add(19, new string[] { "나","63"});
        // talkData.Add(20, new string[] { "혜린","정답! 와, 너 진짜 똑똑하구나? 며칠만에 글도 다 배우고 구구단까지 완벽하네."});
        // talkData.Add(21, new string[] { "나","놀랐…잖아…"});
        // talkData.Add(22, new string[] { "혜린","쑥스러워하기는. 자, 그래서 오늘은 뭐가 궁금해?"});

        dialogList.Add(talkData2);
    }

    public string GetSpeaker(int scence_id, int id)
    {
        if (id>=dialogList[scene_id].Count)
            return null;
        return dialogList[scene_id][id][0];
    }

    public string GetTalk(int scence_id, int id)
    {
        if (id>=dialogList[scene_id].Count)
            return null;
        return dialogList[scene_id][id][1];
    }
}
