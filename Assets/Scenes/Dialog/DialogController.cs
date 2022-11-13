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

    // Event8
    GameObject Event8Option1;
    public TextMeshProUGUI e8o1;
    GameObject Event8Option2;
    public TextMeshProUGUI e8o2;

    // Event2
    GameObject Event2Option1, Event2Option2, Event2Option3;
    public TextMeshProUGUI e2o1, e2o2, e2o3;

    // Event3
    GameObject Event3Option1, Event3Option2;
    public TextMeshProUGUI e3o1, e3o2;

    // Event6
    GameObject Event6Option1, Event6Option2, Event6Option3;
    public TextMeshProUGUI e6o1, e6o2, e6o3;

    public void Talk(){

        scenceId = DataManager.instance.player.day;

        string talkData = GetTalk(scenceId, talkIndex);
        string speakerData = GetSpeaker(scenceId, talkIndex);

        if (speakerData == "%EVENT%") {     // 랜덤 이벤트 

            if (scenceId == 8) {
                // 버튼 활성화
            
                // 버튼 2개 활성화
                Event8Option1 = GameObject.Find("Event8").transform.Find("Event8Option1").gameObject;
                Event8Option1.SetActive(true);
                Event8Option2 = GameObject.Find("Event8").transform.Find("Event8Option2").gameObject;
                Event8Option2.SetActive(true);

                // UI 비활성화
                GameObject.Find("box_dialog").GetComponent<Button>().interactable = false;

                // 버튼 text
                e8o1 = Event8Option1.GetComponentInChildren<TextMeshProUGUI>();
                e8o2 = Event8Option2.GetComponentInChildren<TextMeshProUGUI>();
                e8o1.text = GetOption(scenceId, talkIndex)[0];
                e8o2.text = GetOption(scenceId, talkIndex)[1];
                
                // 버튼 클릭 시 호출되는 함수
            }
            else if (scenceId == 2) {
                // 버튼 활성화
            
                // 버튼 3개 활성화
                Event2Option1 = GameObject.Find("Event2").transform.Find("Event2Option1").gameObject;
                Event2Option1.SetActive(true);
                Event2Option2 = GameObject.Find("Event2").transform.Find("Event2Option2").gameObject;
                Event2Option2.SetActive(true);
                Event2Option3 = GameObject.Find("Event2").transform.Find("Event2Option3").gameObject;
                Event2Option3.SetActive(true);

                // UI 비활성화
                GameObject.Find("box_dialog").GetComponent<Button>().interactable = false;

                // 버튼 text
                e2o1 = Event2Option1.GetComponentInChildren<TextMeshProUGUI>();
                e2o2 = Event2Option2.GetComponentInChildren<TextMeshProUGUI>();
                e2o3 = Event2Option3.GetComponentInChildren<TextMeshProUGUI>();
                e2o1.text = GetOption(scenceId, talkIndex)[0];
                e2o2.text = GetOption(scenceId, talkIndex)[1];
                e2o3.text = GetOption(scenceId, talkIndex)[2];

                // 버튼 클릭 시 호출되는 함수
            }
            else if (scenceId == 3) {
                // 버튼 활성화
            
                // 버튼 2개 활성화
                Event3Option1 = GameObject.Find("Event3").transform.Find("Event3Option1").gameObject;
                Event3Option1.SetActive(true);
                Event3Option2 = GameObject.Find("Event3").transform.Find("Event3Option2").gameObject;
                Event3Option2.SetActive(true);

                // UI 비활성화
                GameObject.Find("box_dialog").GetComponent<Button>().interactable = false;

                // 버튼 text
                e3o1 = Event3Option1.GetComponentInChildren<TextMeshProUGUI>();
                e3o2 = Event3Option2.GetComponentInChildren<TextMeshProUGUI>();
                e3o1.text = GetOption(scenceId, talkIndex)[0];
                e3o2.text = GetOption(scenceId, talkIndex)[1];

                // 버튼 클릭 시 호출되는 함수
            }
            else if (scenceId == 6) {
                // 버튼 활성화
            
                // 버튼 3개 활성화
                Event6Option1 = GameObject.Find("Event6").transform.Find("Event6Option1").gameObject;
                Event6Option1.SetActive(true);
                Event6Option2 = GameObject.Find("Event6").transform.Find("Event6Option2").gameObject;
                Event6Option2.SetActive(true);
                Event6Option3 = GameObject.Find("Event6").transform.Find("Event6Option3").gameObject;
                Event6Option3.SetActive(true);

                // UI 비활성화
                GameObject.Find("box_dialog").GetComponent<Button>().interactable = false;

                // 버튼 text
                e6o1 = Event6Option1.GetComponentInChildren<TextMeshProUGUI>();
                e6o2 = Event6Option2.GetComponentInChildren<TextMeshProUGUI>();
                e6o3 = Event6Option3.GetComponentInChildren<TextMeshProUGUI>();
                e6o1.text = GetOption(scenceId, talkIndex)[0];
                e6o2.text = GetOption(scenceId, talkIndex)[1];
                e6o3.text = GetOption(scenceId, talkIndex)[2];

                // 버튼 클릭 시 호출되는 함수
            }

        }
        else if (speakerData == "%END%") {   // 대사가 끝났을 때
            
            // if (speakerData == "%END%") // 마지막 요일, 마지막 대사 ?
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
        else if (speakerData == "쪽지" | speakerData == "" | speakerData == "일지" | speakerData == "%END%" | speakerData == "%EVENT%" )
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

        if (speakerData != "%EVENT%")
            dialogText.text = talkData;     // 대화창 대화
        
        // isAction = true;
        talkIndex++;
    }

    void GenerateData()
    {

        /*
        **  혜린과의 대화
        */

        // #1 너를 만나지 말았어야 했어
        Dictionary<int, string[]> talkData = new Dictionary<int, string[]>();
        
        // 혜린 A : 기본 A0, 기쁨 A1, 
        // 나 B : 

        talkData.Add(0, new string[] { "","(우당탕탕탕!)"});
        talkData.Add(1, new string[] { "나","(헉. 너무 큰 소리를 냈나? 어두워서 아무것도 보이지 않는다. 여긴 어디지?)"});
        talkData.Add(2, new string[] { "?","누구세요?"});
        talkData.Add(3, new string[] { "나","(이런. 역시 소리가 너무 컸다. 누구지? 누군가 나를 향해 다가온다.)"});
        talkData.Add(4, new string[] { "?","누구세요? 아니.. 여기서 뭘 하고 계시는 거예요?", "0"});
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

        dialogList.Add(1, talkData);    // # 혜린과의 대화 1

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

        dialogList.Add(4, talkData2);   // # 혜린과의 대화 2

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

        dialogList.Add(5, talkData3);    // # 혜린과의 대화 3

        // #4 고요히 내게 말했어
        Dictionary<int, string[]> talkData4 = new Dictionary<int, string[]>();
        talkData4.Add(0, new string[] {"나","오늘은 뭘 하려나…"});
        talkData4.Add(1, new string[] {"나","…"});
        talkData4.Add(2, new string[] {"나","오늘은… 안 오나…?"});
        talkData4.Add(3, new string[] {"%END%",""});

        dialogList.Add(7, talkData4);    // # 혜린과의 대화 4

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
        talkData5.Add(22, new string[] {"%END%","%END%"});

        dialogList.Add(9, talkData5);   // # 혜린과의 대화 5

        /*
        **  고정 이벤트 : 8턴에 등장
        */

        Dictionary<int, string[]> event8 = new Dictionary<int, string[]>();     // # 고정 이벤트

        event8.Add(0, new string[] {"","(똑똑똑…)"});
        event8.Add(1, new string[] {"","누구세요…?"});
        event8.Add(2, new string[] {"","문 밖에서 흠칫 놀라는 소리가 들린다. 이번에는 정말 사람인가? 아 혹시,"});
        event8.Add(3, new string[] {"","혜린…이야?"});
        event8.Add(4, new string[] {"","…혜린이는 아니고요."});
        event8.Add(5, new string[] {"","낯선 목소리다."});
        event8.Add(6, new string[] {"","혜린이 친구인데, 문 좀 잠깐 열어줄래요?"});

        // # 고정 이벤트 결과 1. 문을 연다
        event8.Add(7, new string[] {"%EVENT%","문을 연다", "거부한다"});
        event8.Add(8, new string[] {"","혜린….의... 친구…?"});
        event8.Add(9, new string[] {"","하, 나 이것 봐라. 진짜 여기다 이런 걸 숨겨놓고 있었네."});
        event8.Add(10, new string[] {"%END%","4"}); // ENDING 4

        // # 고정 이벤트 결과 2. 거부한다
        event8.Add(11, new string[] {"","당신은… 혜린의 친구가 맞습니까…?"});
        event8.Add(12, new string[] {"","맞다니까! 문 좀 열어봐요."});
        event8.Add(13, new string[] {"","… 왜 화를 냅니까? 당신은... 혜린의 친구가 아닌 것 같다."});
        event8.Add(14, new string[] {"","… 쓸데없이 이 문은 왜 안에서만 열려가지고는."});
        event8.Add(15, new string[] {"","밖에서 투덜거리는 소리가 들리더니 곧 소란스러운 소리가 들렸다. 곧 문앞의 사람과 누군가가 다투는 소리가 들렸고, 고요해졌다."});
        event8.Add(16, new string[] {"","밖에서 투덜거리는 소리가 들리더니 곧 소란스러운 소리가 들렸다. 곧 문앞의 사람과 누군가가 다투는 소리가 들렸고, 고요해졌다."});
        event8.Add(17, new string[] {"","…갔나…?"});
        event8.Add(18, new string[] {"","여기는 대체 어떤 곳일까? 혜린이 아닌 다른 사람도 존재하고 있구나."});
        event8.Add(19, new string[] {"%END%",""});

        dialogList.Add(8, event8);  
        
        /*
        **  랜덤 이벤트 : 2, 3, 6 턴에 등장
        */

        Dictionary<int, string[]> event2 = new Dictionary<int, string[]>();     // # 랜덤 이벤트 2

        event2.Add(0, new string[] {"나","오늘도 나가볼…."});
        event2.Add(1, new string[] {"","(덜컹-)"});
        event2.Add(2, new string[] {"나","어…...?"});
        event2.Add(3, new string[] {"","(덜컹덜컹-)"});
        event2.Add(4, new string[] {"나","문이 잠겼잖아…....?"});

        // # 고정 이벤트 결과 1. 문을 열어본다
        event2.Add(5, new string[] {"%EVENT%","문을 열어본다", "포기한다", "구애의 춤을 춰본다"});
        event2.Add(6, new string[] {"","문은 여전히 열리지 않는다."});
        event2.Add(7, new string[] {"나","이런... 오늘은 못 나가겠네."});
        event2.Add(8, new string[] {"%END%",""});

        // # 고정 이벤트 결과 2. 포기한다
        event2.Add(9, new string[] {"나","귀찮아… 다…"});
        event2.Add(10, new string[] {"%END%",""});

        // # 고정 이벤트 결과 3. 구애의 춤을 춰본다
        event2.Add(11, new string[] {"","문은 여전히 열리지 않는다."});
        event2.Add(12, new string[] {"나","… 이정도 하면 열릴 때도 됐는데…"});
        event2.Add(13, new string[] {"%END%",""});

        dialogList.Add(2, event2);  



        Dictionary<int, string[]> event3 = new Dictionary<int, string[]>();     // # 랜덤 이벤트 3

        event3.Add(0, new string[] {"","(똑똑똑)"});
        event3.Add(1, new string[] {"나","….누구세요?"});
        event3.Add(2, new string[] {"나","…."});

        // # 고정 이벤트 결과 1. 문을 연다.
        event3.Add(3, new string[] {"%EVENT%","문을 연다", "무시한다"});
        event3.Add(4, new string[] {"","문을 열고 바닥을 보니 작은 곰인형이 있다."});
        event3.Add(5, new string[] {"","누가 놓고 간 거지…?"});
        event3.Add(6, new string[] {"","주변을 봤지만 아무도 찾을 수 없었다. 곰인형을 가지고 방으로 돌아왔다."});
        event3.Add(7, new string[] {"%END%",""});

        // # 고정 이벤트 결과 2. 무시한다.
        event3.Add(8, new string[] {"나","잘못 들었을 것이다. 그 누구도 내 방문을 두드린 적은 없었다."});
        event3.Add(9, new string[] {"","…나를 찾아와주는 친구... 같은 건… 없을테니까…"});
        event3.Add(10, new string[] {"%END%",""});

        dialogList.Add(3, event3);  


        Dictionary<int, string[]> event6 = new Dictionary<int, string[]>();     // # 랜덤 이벤트 6

        event6.Add(0, new string[] {"","(찍찍찍…)"});
        event6.Add(1, new string[] {"나","…? 무슨 소리지?"});
        event6.Add(2, new string[] {"","어둠 속을 가만히 바라보니 무엇인가 움직인다."});
        event6.Add(3, new string[] {"나","쥐인가…?"});

        // # 고정 이벤트 결과 1. 다가간다.
        event6.Add(4, new string[] {"%EVENT%","다가간다", "바라본다", "말을 건다"});
        event6.Add(5, new string[] {"","가까이 다가가자 쥐가 재빨리 달아난다."});
        event6.Add(6, new string[] {"","어디로 사라진 걸까? 사라진 쥐는 어디로 갈까. 이곳 밖에는… 무엇이 있을까?"});
        event6.Add(7, new string[] {"%END%",""});

        // # 고정 이벤트 결과 2. 바라본다.
        event6.Add(8, new string[] {"","다가가고 싶지 않다. 쥐는 날 가만히 보더니 어둠 속으로 사라졌다."});
        event6.Add(9, new string[] {"나","윽…"});
        event6.Add(10, new string[] {"%END%",""});

        // # 고정 이벤트 결과 3. 말을 건다.
        event6.Add(11, new string[] {"나","너는 이름이 뭐야..?"}); 
        event6.Add(12, new string[] {"","(찍찍찍…)"});
        event6.Add(13, new string[] {"나","찍찍이구나…"});
        event6.Add(14, new string[] {"찍찍이","(찍찍찍…)"});
        event6.Add(15, new string[] {"%END%",""});


        dialogList.Add(6, event6);  
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

    public List<string> GetOption(int scenceId, int id)
    {

        List<string> optionList = new List<string>();
        optionList.Add(dialogList[scenceId][id][1]);
        optionList.Add(dialogList[scenceId][id][2]);
        
        if (dialogList[scenceId][id].Length == 4)   // 선택지가 3개인 경우
            optionList.Add(dialogList[scenceId][id][3]);
        
        return optionList;
    }
    void DayPass()
    {
        gameObject.GetComponent<Game>().DayPass();
        gameObject.GetComponent<Game>().Save();
        sceneObject.GetComponent<SwitchScene>().DayMark();
    }

    public void event8_1(){
        talkIndex = 8;
        Event8Option1.SetActive(false);
        Event8Option2.SetActive(false);
        Talk();
        GameObject.Find("box_dialog").GetComponent<Button>().interactable = true;
    }

    public void event8_2(){
        talkIndex = 11;
        Event8Option1.SetActive(false);
        Event8Option2.SetActive(false);
        Talk();
        GameObject.Find("box_dialog").GetComponent<Button>().interactable = true;
    }

    public void event2_1(){
        talkIndex = 6;
        Event2Option1.SetActive(false);
        Event2Option2.SetActive(false);
        Event2Option3.SetActive(false);
        Talk();
        GameObject.Find("box_dialog").GetComponent<Button>().interactable = true;
    }

    public void event2_2(){
        talkIndex = 9;
        Event2Option1.SetActive(false);
        Event2Option2.SetActive(false);
        Event2Option3.SetActive(false);
        Talk();
        GameObject.Find("box_dialog").GetComponent<Button>().interactable = true;
    }
    public void event2_3(){
        talkIndex = 11;
        Event2Option1.SetActive(false);
        Event2Option2.SetActive(false);
        Event2Option3.SetActive(false);
        Talk();
        GameObject.Find("box_dialog").GetComponent<Button>().interactable = true;
    }

    // Event3
    public void event3_1(){
        talkIndex = 4;
        Event3Option1.SetActive(false);
        Event3Option2.SetActive(false);
        Talk();
        GameObject.Find("box_dialog").GetComponent<Button>().interactable = true;
    }
    public void event3_2(){
        talkIndex = 8;
        Event3Option1.SetActive(false);
        Event3Option2.SetActive(false);
        Talk();
        GameObject.Find("box_dialog").GetComponent<Button>().interactable = true;
    }

    // Event6
    public void event6_1(){
        talkIndex = 5;
        Event6Option1.SetActive(false);
        Event6Option2.SetActive(false);
        Event6Option3.SetActive(false);
        Talk();
        GameObject.Find("box_dialog").GetComponent<Button>().interactable = true;
    }
    public void event6_2(){
        talkIndex = 8;
        Event6Option1.SetActive(false);
        Event6Option2.SetActive(false);
        Event6Option3.SetActive(false);
        Talk();
        GameObject.Find("box_dialog").GetComponent<Button>().interactable = true;
    }
    public void event6_3(){
        talkIndex = 11;
        Event6Option1.SetActive(false);
        Event6Option2.SetActive(false);
        Event6Option3.SetActive(false);
        Talk();
        GameObject.Find("box_dialog").GetComponent<Button>().interactable = true;
    }
}
