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

    public int scenceId;

    public GameObject gameObject;   // 게임오브젝트 : 게임 매니저
    public GameObject sceneObject;  // 게임오브젝트 : 씬 매니저

    Dictionary<int,Dictionary<int, string[]>> dialogList;

    void Awake() {
        dialogList = new Dictionary<int, Dictionary<int, string[]>>();
        
        GenerateData();
        talkIndex = 0;

        Talk();
    }

    void Update() {
    }

    public void Talk(){

        scenceId = DataManager.instance.player.day -1;

        string talkData = GetTalk(scenceId, talkIndex);
        string speakerData = GetSpeaker(scenceId, talkIndex);

        if (speakerData == "%END%") {   // 대사가 끝났을 때
            
            // if (scenceId == 4) // 마지막 요일, 마지막 대사 ?
            // {

            // }

            // isAction = false;
            // boxDialog.SetActive(false); // 대화창 비활성화
            // boxName.SetActive(false);   // 이름창 비활성화

            // dialogText.text = "";
            // nameText.text = "";
            talkIndex = 0;

            Invoke("DayPass", 1f);      // 하루 지나간다

            return;
        }

        if (speakerData == "쪽지" | speakerData == "" | speakerData == "일지")
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
        // #1 너를 만나지 말았어야 했어
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
        talkData.Add(14, new string[] {"%END%",""});   

        dialogList.Add(0, talkData);

        // #2 도서관에서
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
        talkData2.Add(17, new string[] {"%END%",""});

        dialogList.Add(1, talkData2);

        // #3 나를 보던 너의 표정이
        Dictionary<int, string[]> talkData3 = new Dictionary<int, string[]>();
        talkData3.Add(0, new string[] { "나","(복도가 온통 구구단 쪽지로 가득하다. 이걸 대체 왜 배워야하는 건지...)"});
        talkData3.Add(1, new string[] { "혜린","7 X 9?"});
        talkData3.Add(2, new string[] { "나","63"});
        talkData3.Add(3, new string[] { "혜린","정답! 와, 너 진짜 똑똑하구나? 며칠만에 글도 다 배우고 구구단까지 완벽하네."});
        talkData3.Add(4, new string[] { "나","놀랐…잖아…"});
        talkData3.Add(5, new string[] { "혜린","쑥스러워하기는. 자, 그래서 오늘은 뭐가 궁금해?"});
        talkData3.Add(6, new string[] { "나","책..에서 봤어.. 깜깜한 것은 밤..이고.. 밤..에는.. 위에.. 별..이 뜬다… 별…이 이곳에도 있어…?"});
        talkData3.Add(7, new string[] { "혜린","아하. 아쉽게도 별은 없어. 별은 하늘에 있는데, 여기엔 천장밖에 없으니까. 아마 높은 곳에 올라가면 별이 보이겠지. 다른 질문은?"});
        talkData3.Add(8, new string[] { "나","책…에 나오는… 주인공들… 다… 이름…이 있다… 내… 이름은… 뭐야…?"});
        talkData3.Add(9, new string[] { "혜린","아. 이름은 주인공들한테만 있는 거야. 너는 주인공이 아니니까 없지. 다른 질문은?"});
        talkData3.Add(10, new string[] { "나","(…너는 주인공이고… 나는 주인공이 아니라는 건가…? 무슨 말을 해야할지 잘 모르겠다...)"});
        talkData3.Add(11, new string[] { "나","그런데 혜린… 너는 항상 뭘 적는 거야? 나랑 만날 때마다 무엇인가를 적잖아."});
        talkData3.Add(12, new string[] { "혜린","아, 그게 궁금했어? 일기라는 거야. 그럼 오늘은 너도 일기를 써보자! 자, 연필은 이렇게 잡는거야. 따라해봐."});
        talkData3.Add(13, new string[] { "나","(서툴게 따라한다.)"});
        talkData3.Add(14, new string[] { "혜린","…"});
        talkData3.Add(15, new string[] {"%END%",""});

        dialogList.Add(2, talkData3);

        // #4 고요히 내게 말했어
        Dictionary<int, string[]> talkData4 = new Dictionary<int, string[]>();
        talkData4.Add(0, new string[] {"나","오늘은 뭘 하려나…"});
        talkData4.Add(1, new string[] {"나","…"});
        talkData4.Add(2, new string[] {"나","오늘은… 안 오나…?"});
        talkData4.Add(3, new string[] {"%END%",""});

        dialogList.Add(3, talkData4);

        // #5 내가 괴물이라고
        Dictionary<int, string[]> talkData5 = new Dictionary<int, string[]>();
        talkData5.Add(0, new string[] {"나","혜린.. 오늘도 없나..."});
        talkData5.Add(1, new string[] {"","(책상 위에 노트가 있다. 혜린의 것인 것 같다.)"});
        talkData5.Add(2, new string[] {"나","한번 볼까…"});
        // TODO : 붉은색 글씨는 혜린의 일지 내용입니다. 글씨체 변경 필요.
        talkData5.Add(3, new string[] {"일지","5월 5일. 눈을 떴다. 눈을 감고 뜨는 것만 가능해 보인다."});
        talkData5.Add(4, new string[] {"일지","5월 6일. 나를 가만히 바라본다. 나를 기억할까? 곧 말을 할 수 있을까? 어디까지 학습을 시킬 수 있을까. 아니, 학습을 시킬 수 있을까? 무엇이든 새로운 영역의 발견이다."});
        talkData5.Add(5, new string[] {"나","무슨 소리인지 모르겠네… 뒤쪽을 볼까."});
        talkData5.Add(6, new string[] {"일지","11월 5일. 한동안 까먹고 있었는데 복도에서 마주쳤다. 아직 살아있었네. 이제 다리도 움직일 수 있나보네. 나를 보고 고개를 끄덕인다. 의사소통도 가능한건가? 흥미가 생긴다."});
        talkData5.Add(7, new string[] {"나","….?"});
        talkData5.Add(8, new string[] {"일지","11월 8일. 한글을 읽고 쓸 수 있음. 수학의 경우 구구단 암기부터 시도해볼 예정. 학습이 가능한 것이 증명되었다. 어디까지 고도화시킬 수 있을까."});
        talkData5.Add(9, new string[] {"일지","11월 9일. 글을 쓰는 것까지 가능하다. 괴물이 되기 전의 지능을 그대로 갖고 있는 것으로 추정된다. 기존의 지능을 뛰어넘는 성장도 가능한가?"});
        talkData5.Add(10, new string[] {"","(그리고 아래 줄이 그어져있는 부분이 있다.)"});
        talkData5.Add(11, new string[] {"일지","이름? 괴물에게 이름이 가당키나한가?"});
        talkData5.Add(12, new string[] {"나","괴물…? 내가...? 괴물…?"});
        talkData5.Add(13, new string[] {"","(책에서 본 적이 있다. 그런데 나는… 나는 그런 게 아닌데. 나는…)"});
        talkData5.Add(14, new string[] {"","(일기장의 마지막 페이지를 급하게 넘겼다. 마지막 페이지에 사진과 함께 짧은 글이 적혀있다.)"});
        talkData5.Add(15, new string[] {"일지","거울. 빛의 반사를 이용하여 물체의 모양을 비추어 보는 물건. 책상 첫 번째 서랍에."});
        talkData5.Add(16, new string[] {"나","거울..? 처음 보는 건데.."});
        talkData5.Add(17, new string[] {"","(그리고 맨 아래에 급하게 휘갈겨 쓴 마지막 문장이 보인다.)"});
        talkData5.Add(18, new string[] {"일지","네가 누군지 궁금하다면 나를 찾아와. 별과 가장 가까운 높은 곳에서 널 기다릴게."});
        talkData5.Add(19, new string[] {"나","…"});
        talkData5.Add(20, new string[] {"","(책상 서랍을 열었다. 손바닥만한 물건이 있다. 저게 거울인가? 물건을 들어 뒤집어본다. 이리저리 흔들어보니)"});
        talkData5.Add(21, new string[] {"나","이… 이게 뭐야….?"});
        talkData5.Add(22, new string[] {"%END%",""});

        dialogList.Add(4, talkData5);
   }

    public string GetSpeaker(int scenceId, int id)
    {
        if (id>=dialogList[scenceId].Count)
            return null;
        return dialogList[scenceId][id][0];
    }

    public string GetTalk(int scenceId, int id)
    {
        if (id>=dialogList[scenceId].Count)
            return null;
        return dialogList[scenceId][id][1];
    }

    void DayPass()
    {
        gameObject.GetComponent<Game>().DayPass();
        gameObject.GetComponent<Game>().Save();
        sceneObject.GetComponent<SwitchScene>().DayMark();
    }
}
