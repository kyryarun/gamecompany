using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public float goal_complete; //목표 완성도
    public float goal_fun; //목표 재미
    public float now_complete; //현재 완성도
    public float now_fun; //현재 재미

    float pre_comp; //이벤트 적용전 수치
    float pre_fun; //이벤트 적용전 수치
    // Start is called before the first frame update

    public work_list work_List; //백업.
    public Event_list event_List;
    public level_select Game_Level;

    //멤버 설정
    public List<member> members;

    public member mem1;
    public member mem2;
    public member mem3;
    public member mem4;
    public member mem5;

    public int retire_number; //리타이어한 팀원의 수
    public int save_number; //살아남은 팀원의 수

    public member now_member; //업무를 진행할 멤버
    public member pre_member; //이전에 업무를 진행한 멤버

    public bool end_work = false; //이번 업무가 끝났다는 이야기
    public bool start_event = false; //이벤트 분배를 시작했다는 표시.
    public bool end_event = false; //이번 이벤트가 끝났다는 이야기
    public bool end_step = false; //이번 업무와 이벤트가 모두 끝나고 다음 스텝으로 넘어가기 직전이라는 표시.
    public int cycle_time = 0; //몇번 반복(업무와 이벤트)했는지 표시
    public bool end_time; //엔딩시간이 되었다는 표시.
    public bool the_end; //끝이라는 표시

    public int total_event = 0; //전체 이벤트의 횟수

    public int retire_limit; //리타이어 게임오버 제한 인원

    //메인화면
    public MainpageButton mainpageButton; //메인화면의 스크립트

    //게임화면
    public GameObject gameplay_UI; //게임화면의 오브젝트

    //결과화면
    public ResultScript resultScript; //결과화면의 스크립트

    //엔딩화면
    public EndScene endScene; //엔딩화면의 스크립트

    //옵션
    public OptionScript optionScript; //옵션의 스크립트

    public audio_set audio_Setting; //오디오 매니저


    //인벤토리
    public Inventory inventory; //인벤토리 스크립트

    //상점
    public Store store; //상점의 스크립트
    public int player_gold; //플레이어의 소지 골드
    public Text gold_text; //골드 표시 텍스트

    //멤버 데이터 관리
    public member_data member_Data; //멤버의 데이터 관리 스크립트
    public bool TestBool;

    public void set_gold()
    {
        gold_text.text = player_gold.ToString();
    }

    //싱글톤
    static Gamemanager Instance;

    public static Gamemanager GetInstance()
    {
        return Instance;
    }

    public Text complete;
    public Text fun;
    public Text cycle; //회차

    private void Awake()
    {
        Instance = this;
        members = new List<member>(5);
        members.Add(mem1);
        members.Add(mem2);
        members.Add(mem3);
        members.Add(mem4);
        members.Add(mem5);
        //member_Data.data_set();
    }

    void Start()
    {
        TestBool = DataManager.Instance.gameData.isAcivment_1;
    }

    public void PlayDataCheck()
    {
        if (PlayDataManager.Play_Instance.PlayFileCheck())
        {
            Debug.Log("플레이 데이터 존재");
        }
    }

    public void LoadPlayerGold()
    {
        if (PlayDataManager.Play_Instance.PlayFileCheck())
        {
            PlayDataManager.Play_Instance.LoadGameData();
            player_gold = PlayDataManager.Play_Instance.playData.Own_Coin;
            Debug.Log("게임 플레이 로드 성공");
        }
    }

    public void SavePlayerGold()
    {
        PlayDataManager.Play_Instance.playData.Own_Coin = player_gold;
        PlayDataManager.Play_Instance.SaveGameData();
        Debug.Log("게임 플레이 저장 성공");
    }

    public void PlayDataDelete()
    {
        if (PlayDataManager.Play_Instance.DeleteGameData())
            Debug.Log("게임 플레이 삭제 성공");
    }

    // Update is called once per frame
    void Update()
    {
        if (end_time == false)
        {
            if (end_work == false)
            {
                if (now_member == null)
                {
                    select_member();
                }
            }
            check_member();
            check_work();
            work_start();
            event_start();
            //cal_evet();
            next_statin();
            //update_text();
            number_set();
            Now_Member_Back_Setting();
            copy_value_to_result();
        }
        if (the_end == false)
        {
            ending_set();
        }
        set_gold();
    }

    public void select_member() //현재 업무를 할 팀원 선정
    {
        for (int i = 0; i < members.Count; i++)
        {
            if (members[i].isretire == false)
            {
                //Debug.Log(i);
                if (members[i].select_work_number == -1)
                {
                    //if (now_member)
                    //{
                    //    pre_member = now_member;
                    //}
                    now_member = members[i];
                    break;
                }
            }
        }
    }

    public void work_start() //팀원에게 업무 설정
    {
        if (now_member)
        {
            if (now_member.select_work_number != -1)
            {
                int type_num = -1;
                switch (now_member.work_type)
                {
                    case member.type.Design:
                        type_num = 0;
                        break;
                    case member.type.Programer:
                        type_num = 1;
                        break;
                    case member.type.Art:
                        type_num = 2;
                        break;
                }
                if (now_member.select_work_number == 13)
                {
                    now_member.next_work = work_List.worklist[12];
                }
                else
                {
                    now_member.next_work = work_List.worklist[type_num * 4 + now_member.select_work_number - 1];
                }
            }
        }
    }

    public void check_member() //팀원들의 상태(리타이어여부)를 확인하는 함수
    {
        retire_number = 0;
        save_number = 0;
        for (int i = 0; i < members.Count; i++)
        {
            if (members[i].isretire)
            {
                retire_number++;
            }
            else
            {
                save_number++;
            }
        }
    }

    public void check_work() //팀원들이 업무를 끝냈는지 판단하는 함수
    {
        int j = 0; //업무를 끝낸 팀원계산
        for (int i = 0; i < members.Count; i++)
        {
            if (members[i].isretire == false)
            {
                if (members[i].iswork)
                {
                    j++;
                }
            }
        }
        if (j == save_number)
        {
            end_work = true;
        }
        else
        {
            end_work = false;
        }




    }

    public void event_start() //팀원에게 이벤트 설정
    {
        if (end_work == true)
        {
            if (start_event == false)
            {
                pre_comp = now_complete;
                pre_fun = now_fun;

                for (int i = 0; i < members.Count; i++)
                {
                    if (members[i].isretire == false)
                    {
                        members[i].select_event();
                        int type_num = -1;
                        switch (members[i].work_type)
                        {
                            case member.type.Design:
                                type_num = 0;
                                break;
                            case member.type.Programer:
                                type_num = 1;
                                break;
                            case member.type.Art:
                                type_num = 2;
                                break;
                        }

                        if (members[i].pn_number == -1)
                        {
                            members[i].next_event = Gamemanager.GetInstance().event_List.event_List[24];
                        }
                        else if (members[i].pn_number != -1)
                        {
                            members[i].next_event = Gamemanager.GetInstance().event_List.event_List[(members[i].pn_number * 12) + type_num * 4 + members[i].select_event_number - 1];
                        }
                    }
                    else if (members[i].isretire == true)
                    {
                        members[i].next_event = Gamemanager.GetInstance().event_List.event_List[25];
                    }
                }
                start_event = true;
            }
        }
    }

    public void cal_evet() //이벤트 계산
    {
        if (end_work == true)
        {
            if (start_event == true)
            {
                if (end_event == false)
                {
                    for (int i = 0; i < members.Count; i++)
                    {
                        members[i].set_event();
                    }
                    Debug.Log("현재의 완성도 : " + now_complete);
                    Debug.Log("현재의 재미 : " + now_fun);
                    end_event = true;
                }
            }
        }
    }

    public void next_statin() //한번의 행동(업무와 이벤트)가 끝나면 다음 행동으로 넘어가는 함수.
    {
        if (end_work && start_event && end_event && end_step)
        {
            for (int i = 0; i < members.Count; i++)
            {
                members[i].Init();
            }
            end_work = false;
            start_event = false;
            end_event = false;
            end_step = false;
            pre_member = null;
            cycle_time++;
        }
    }

    public void update_text()
    {
        complete.text = (now_complete.ToString() + " / " + goal_complete.ToString());
        fun.text = (now_fun.ToString() + " / " + goal_fun.ToString());
        if (start_event)
        {
            cycle.text = (cycle_time + 1).ToString() + "번째 " + "이벤트";
        }
        else //if (end_work)
        {
            cycle.text = (cycle_time + 1).ToString() + "번째 " + "업무";
        }

    }

    public void number_set()
    {
        if (now_complete < 0)
        {
            now_complete = 0;
        }
        if (now_fun < 0)
        {
            now_fun = 0;
        }
        if (now_complete > goal_complete)
        {
            now_complete = goal_complete;
        }
        if (now_fun > goal_fun)
        {
            now_fun = goal_fun;
        }
    }

    public void Result_Scene()
    {
        resultScript.gameObject.SetActive(true);
    }

    public void ending_set()  // 회차 제한
    {
        if (cycle_time > 5)
        {
            end_time = true;
        }
        if (end_time)
        {

            UIManager.GetIntstance().m_Game_State_UI[0].SetActive(false);//게임플레이 화면 끄기

            //if ((now_complete >= goal_complete) && (now_fun >= goal_fun))
            //{
            //    Debug.Log("승진!!!");
            //}
            //else if (now_complete >= goal_complete && now_fun >= 40)
            //{
            //    Debug.Log("근속!");
            //}
            //else if (now_complete >= 80 && now_fun >= 80)
            //{
            //    Debug.Log("근속!");
            //}
            //else
            //{
            //    Debug.Log("퇴사....");
            //}
            the_end = true;
        }

    }

    public void restart_game() //게임 재시작
    {
        if (the_end)
        {
            //1. 게임매니저를 재설정.
            now_complete = 0;
            now_fun = 0;
            cycle_time = 0;
            total_event = 0;
            end_time = false;
            the_end = false;
            pre_member = null;
            UIManager.GetIntstance().m_StoryUI_Button.m_Scene = 0; // 스토리 씬 초기화;
            UIManager.GetIntstance().m_StoryUI_Button.Change_Story_Scene(0);

            //만약을 대비해서
            end_work = false;
            start_event = false;
            end_event = false;
            end_step = false;

            //2. 팀원을 재설정.
            for (int i = 0; i < members.Count; i++)
            {
                members[i].Init();
                members[i].tired_parameter = 0;
                members[i].isretire = false;
                members[i].Tired_Max_Obj.SetActive(false);
                //여기에 피로도바를 갱신하도록 해야한다.
            }
        }
    }

    public void game_Over() //리타이어 인원이 몇명이상일때 즉시 게임종료.
    {
        if (retire_number >= retire_limit)
        {
            end_time = true;
        }
    }

    public void game_End() // 엔딩 조건이 충족되면 바로 엔딩.
    {
        if ((now_complete >= goal_complete) && (now_fun >= goal_fun))
        {
            end_time = true;
        }
    }

    public void SetWorkNumber(int number)
    {
        if (!end_work && now_member)
        {
            now_member.select_work_number = number;
        }
    }

    public void UpdateUserInfo()
    {
        UIManager.GetIntstance().m_UserInfo_Update.Set_UserInfo_UI();
    }

    public void Now_Member_Back_Setting()
    {
        if (!end_work && now_member)
        {
            now_member.Now_member_Obj.SetActive(true);

            if (pre_member)
                pre_member.Now_member_Obj.SetActive(false);
        }
        else if (pre_member)
        {
            pre_member.Now_member_Obj.SetActive(false);
        }
    }

    public void copy_value_to_result()
    {
        resultScript.Perfection = now_complete;
        resultScript.howFun = now_fun;
        resultScript.goal_per = goal_complete;
        resultScript.goal_fun = goal_fun;

        endScene.Perfection = now_complete;
        endScene.howFun = now_fun;
        endScene.survived = save_number;
        endScene.eventNum = total_event;
    }

    public void endstep() //버튼에 추가할 함수
    {
        end_step = true;
    }

    public void PlayDataSave()  // 특정 상황일 때 게임 플레이 데이터를 저장한다.
    {
        PlayDataManager PlayInstance = PlayDataManager.Play_Instance;
        // 골드 저장
        PlayInstance.playData.Own_Coin = player_gold;
        // 포션 개수 저장
        PlayInstance.playData.Tired_Potion_1 = inventory.slots[0].itemCount;
        PlayInstance.playData.Tired_Potion_2 = inventory.slots[1].itemCount;
        PlayInstance.playData.Tired_Potion_3 = inventory.slots[2].itemCount;
        PlayInstance.playData.Resurrection_Potion_4 = inventory.slots[3].itemCount;
        PlayInstance.playData.Power_Up_Potion_5 = inventory.slots[4].itemCount;
        // 진행 상황 저장
        PlayInstance.playData.Goal_Complete = goal_complete;  // 목표 완성도
        PlayInstance.playData.Goal_Fun = goal_fun;  // 목표 재미
        PlayInstance.playData.Cur_Complete = now_complete;  // 현재 완성도
        PlayInstance.playData.Retired_Count = retire_number;

        PlayInstance.playData.Cur_Fun = now_fun;  // 현재 재미
        PlayInstance.playData.Cur_Day = cycle_time;  // 날짜
        //PlayInstance.playData.Cur_Quarter ;  // 이건 모르겠음 분기
        PlayInstance.playData.Cur_Level = (int)Game_Level.cur_level; // 0 = 노말 1 = 어려움 2 = 매우 어려움  //난이도 저장

        // 캐릭터 능력치 저장
        for (int i = 0; i < members.Count; i++)
        {
            PlayInstance.playData.character_Status_Plays[i] = members[i].character_Status_play;
        }

        PlayInstance.SaveGameData();
    }

    public void PlayDataLoad()
    {
        PlayDataManager PlayInstance = PlayDataManager.Play_Instance;

        PlayInstance.LoadGameData();

        // 골드 불러오기
        player_gold = PlayInstance.playData.Own_Coin;
        // 아이템 불러오기
        inventory.slots[0].itemCount = PlayInstance.playData.Tired_Potion_1;
        inventory.slots[1].itemCount = PlayInstance.playData.Tired_Potion_2;
        inventory.slots[2].itemCount = PlayInstance.playData.Tired_Potion_3;
        inventory.slots[3].itemCount = PlayInstance.playData.Resurrection_Potion_4;
        inventory.slots[4].itemCount = PlayInstance.playData.Power_Up_Potion_5;
        // 진행 상황 불러오기
        goal_complete = PlayInstance.playData.Goal_Complete;
        goal_fun = PlayInstance.playData.Goal_Fun;
        now_complete = PlayInstance.playData.Cur_Complete;
        now_fun = PlayInstance.playData.Cur_Fun;
        cycle_time = PlayInstance.playData.Cur_Day;
        // Quater = PlayInstance.playData.Cur_Quarter;  // 분기
        Game_Level.cur_level = (level_select.LEVEL)PlayInstance.playData.Cur_Level;  // 난이도

        for(int i = 0; i < members.Count; i++)
        {
            members[i].character_Status_play = PlayInstance.playData.character_Status_Plays[i];
        }

    }
}
