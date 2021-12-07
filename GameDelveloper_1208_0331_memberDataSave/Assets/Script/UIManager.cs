using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    static UIManager Instance;

    public static UIManager GetIntstance()
    {
        return Instance;
    }
    public enum GameState  // 게임화면, 결과화면
    {
        GamePlay,
        Quarter,
        Cycle,
        End,
        Story
    }
    public GameState cur_UI_State;

    public enum ButtonUIState  // 게임화면 내 우측 UI 상태
    {
        Select,
        Result,
        Progress
    }

    public ButtonUIState cur_Button_UI_State;

    public enum SelectUIState
    {
        Planner,
        Programmer,
        Art
    }

    public SelectUIState cur_Select_UI_State;

    public enum QuarterUIState
    {
        Event,
        EventEffect,
        Result
    }

    public QuarterUIState cur_Quarter_UI_State;

    public List<GameObject> m_Game_State_UI;
    public List<GameObject> m_Story_State_UI;
    public List<GameObject> m_Button_State_UI;
    public List<GameObject> m_Select_State_UI;
    public List<GameObject> m_Quater_State_UI;

    public GameObject m_Fade_UI;
    Image Fade_Img;
    Color Fade_Color;
    public GameObject m_Explain_UI;

    public UserInfoUpdate m_UserInfo_Update;
    public QuarterInfoUpdate m_QuarterInfo_Update;
    public StoryUI_Button m_StoryUI_Button;

    public TextMeshProUGUI m_InGame_Cycle_Text;
    public TextMeshProUGUI m_Result_Cycle_Text;
    public TextMeshProUGUI m_Quarter_Cycle_Text;

    public float m_curTime;
    public float m_FadeInTime;
    public float m_MaxTime;

    private void Start()
    {
        Instance = this;
        m_UserInfo_Update = this.gameObject.GetComponent<UserInfoUpdate>();
        m_QuarterInfo_Update = this.gameObject.GetComponent<QuarterInfoUpdate>();
        Fade_Img = m_Fade_UI.GetComponent<Image>();
        Fade_Color = Fade_Img.color;
    }
    // Update is called once per frame
    void Update()
    {
        UISetting();
        SelectSceneChange();
        SetCycleTime();
    }

    public void SetCycleTime()
    {
        if (Gamemanager.GetInstance().cycle_time != 6 && Gamemanager.GetInstance().end_time == false)
        {
            switch (Gamemanager.GetInstance().cycle_time + 1)
            {
                case 1:
                    m_InGame_Cycle_Text.text = string.Format($"1일차 오전");
                    m_Quarter_Cycle_Text.text = string.Format($"1일차 오전 업무 결과");
                    break;
                case 2:
                    m_InGame_Cycle_Text.text = string.Format($"1일차 오후");
                    m_Result_Cycle_Text.text = string.Format($"1일차 오후 업무 시작...");
                    m_Quarter_Cycle_Text.text = string.Format($"1일차 오후 업무 결과");
                    break;
                case 3:
                    m_InGame_Cycle_Text.text = string.Format($"2일차 오전");
                    m_Result_Cycle_Text.text = string.Format($"2일차 오전 업무 시작...");
                    m_Quarter_Cycle_Text.text = string.Format($"2일차 오전 업무 결과");
                    break;
                case 4:
                    m_InGame_Cycle_Text.text = string.Format($"2일차 오후");
                    m_Result_Cycle_Text.text = string.Format($"2일차 오후 업무 시작...");
                    m_Quarter_Cycle_Text.text = string.Format($"2일차 오후 업무 결과");
                    break;
                case 5:
                    m_InGame_Cycle_Text.text = string.Format($"3일차 오전");
                    m_Result_Cycle_Text.text = string.Format($"3일차 오전 업무 시작...");
                    m_Quarter_Cycle_Text.text = string.Format($"3일차 오전 업무 결과");
                    break;
                case 6:
                    m_InGame_Cycle_Text.text = string.Format($"3일차 오후");
                    m_Result_Cycle_Text.text = string.Format($"3일차 오후 업무 시작...");
                    m_Quarter_Cycle_Text.text = string.Format($"3일차 오후 업무 결과");
                    break;
            }
        }
    }

    public void UISetting()  // 현재 상태에 맞게 UI 설정
    {
        switch(cur_UI_State)  // GamePlay 와 Quarter UI 를 설정한다.
        {
            case GameState.GamePlay:            // 게임 플레이
                if(Gamemanager.GetInstance().the_end)
                    ToggleGameUI("GamePlay");
                break;
            case GameState.Quarter:             // 분기
                ToggleGameUI("Quarter");
                m_curTime = 0;
                break;
            case GameState.Cycle:
                ToggleGameUI("Cycle");
                break;
            case GameState.End:
                ToggleGameUI("End");
                break;
            case GameState.Story:
                ToggleGameUI("Story");
                break;
        }

        if(m_Game_State_UI[0].activeSelf)  // 게임 진행 상태 UI 가 Active 일때 실행된다.
        {
            switch(cur_Button_UI_State)
            {
                case ButtonUIState.Select:
                    ToggleButtonUI("Select");
                    break;
                case ButtonUIState.Result:
                    ToggleButtonUI("Result");
                    break;
                case ButtonUIState.Progress:
                    ToggleButtonUI("Progress");
                    break;

            }
        }

        if(m_Button_State_UI[0].activeSelf)  // Button Select UI 가 Active 상태일 때 실행된다.
        {
            switch (cur_Select_UI_State)
            {
                case SelectUIState.Planner:
                    ToggleSelectUI("Planner");
                    break;
                case SelectUIState.Programmer:
                    ToggleSelectUI("Programmer");
                    break;
                case SelectUIState.Art:
                    ToggleSelectUI("Art");
                    break;
            }
        }

        if(m_Game_State_UI[1].activeSelf)
        {
            switch(cur_Quarter_UI_State)
            {
                case QuarterUIState.Event:
                    ToggleQuarterUI("Event");
                    break;
                case QuarterUIState.EventEffect:
                    ToggleQuarterUI("EventEffect");
                    break;
                case QuarterUIState.Result:
                    ToggleQuarterUI("Result");
                    break;
            }
        }
    }

    public void ToggleGameUI(string uiName)  // string 으로 이름을 받고 해당 이름에 맞는 UI를 Active 한다.
    {
        switch(uiName)
        {
            case "GamePlay":
                cur_UI_State = GameState.GamePlay;
                m_Game_State_UI[0].SetActive(true);  // 게임 플레이
                m_Game_State_UI[1].SetActive(false);  // 분기 결과
                m_Game_State_UI[2].SetActive(false);  // 분기 시간 알림
                m_Game_State_UI[3].SetActive(false);  // 엔딩
                m_Game_State_UI[4].SetActive(false);
                break;
            case "Quarter":
                if (Gamemanager.GetInstance().start_event)
                {
                    cur_UI_State = GameState.Quarter;
                    m_Game_State_UI[0].SetActive(false);
                    m_Game_State_UI[1].SetActive(true);
                    m_Game_State_UI[2].SetActive(false);
                    m_Game_State_UI[3].SetActive(false);
                    m_Game_State_UI[4].SetActive(false);
                }
                break;
            case "Cycle":
                {
                    m_curTime += Time.deltaTime;

                    if(Gamemanager.GetInstance().cycle_time == 6 || Gamemanager.GetInstance().end_time == true )
                    {
                        m_Result_Cycle_Text.text = "게임 개발중...";
                    }

                    if (m_curTime < m_MaxTime)
                    {
                        if(m_curTime > m_FadeInTime)
                        {
                            m_Fade_UI.SetActive(true);

                            Fade_Color.a += 0.5f * Time.deltaTime;
                            Fade_Img.color = Fade_Color;
                        }
                        cur_UI_State = GameState.Cycle;
                        m_Game_State_UI[0].SetActive(false);
                        m_Game_State_UI[1].SetActive(false);
                        m_Game_State_UI[2].SetActive(true);
                        m_Game_State_UI[3].SetActive(false);
                        m_Game_State_UI[4].SetActive(false);
                    }
                    else
                    {
                        Fade_Color.a = 0;
                        m_Fade_UI.SetActive(false);
                        if (Gamemanager.GetInstance().cycle_time != 6 && Gamemanager.GetInstance().end_time == false)
                            ToggleGameUI("GamePlay");
                        else if(Gamemanager.GetInstance().cycle_time == 6 || Gamemanager.GetInstance().end_time == true)
                        {
                            Gamemanager.GetInstance().game_End();
                            Gamemanager.GetInstance().game_Over();
                            Gamemanager.GetInstance().Result_Scene();
                        }
                    }    
                }
                break;
            case "End":
                {
                    cur_UI_State = GameState.End;
                    m_Game_State_UI[0].SetActive(false);
                    m_Game_State_UI[1].SetActive(false);
                    m_Game_State_UI[2].SetActive(false);
                    m_Game_State_UI[3].SetActive(true);
                    m_Game_State_UI[4].SetActive(false);
                }
                break;
            case "Story": 
                cur_UI_State = GameState.Story;
                m_Game_State_UI[0].SetActive(false);
                m_Game_State_UI[1].SetActive(false);
                m_Game_State_UI[2].SetActive(false);
                m_Game_State_UI[3].SetActive(false);
                m_Game_State_UI[4].SetActive(true);
                break;
            default:
                Debug.Log("ToggleUI NameError");
                break;
        }

    }

    public void ToggleButtonUI(string uiName)  // string 으로 이름을 받고 해당 이름에 맞는 UI를 Active 한다.
    {
        
            switch (uiName)
            {
                case "Select":
                    cur_Button_UI_State = ButtonUIState.Select;
                    m_Button_State_UI[0].SetActive(true);
                    m_Button_State_UI[1].SetActive(false);
                    m_Button_State_UI[2].SetActive(false);
                    break;
                case "Result":
                if (Gamemanager.GetInstance().end_work == false && Gamemanager.GetInstance().end_time == false)
                {
                    cur_Button_UI_State = ButtonUIState.Result;
                    m_Button_State_UI[0].SetActive(false);
                    m_Button_State_UI[1].SetActive(true);
                    m_Button_State_UI[2].SetActive(false);
                }
                    break;
                case "Progress":
                    cur_Button_UI_State = ButtonUIState.Progress;
                    m_Button_State_UI[0].SetActive(false);
                    m_Button_State_UI[1].SetActive(false);
                    m_Button_State_UI[2].SetActive(true);
                    break;
                default:
                    Debug.Log("ToggleButtonUI NameError");
                    break;
            
        }

    }

    public void ToggleSelectUI(string uiName)  // string 으로 이름을 받고 해당 이름에 맞는 UI를 Active 한다.
    {
        switch (uiName)
        {
            case "Planner":
                cur_Select_UI_State = SelectUIState.Planner;
                m_Select_State_UI[0].SetActive(true);
                m_Select_State_UI[1].SetActive(false);
                m_Select_State_UI[2].SetActive(false);
                break;
            case "Programmer":
                cur_Select_UI_State = SelectUIState.Programmer;
                m_Select_State_UI[0].SetActive(false);
                m_Select_State_UI[1].SetActive(true);
                m_Select_State_UI[2].SetActive(false);
                break;
            case "Art":
                cur_Select_UI_State = SelectUIState.Art;
                m_Select_State_UI[0].SetActive(false);
                m_Select_State_UI[1].SetActive(false);
                m_Select_State_UI[2].SetActive(true);
                break;
            default:
                Debug.Log("ToggleUI NameError");
                break;
        }
    }
    public void ToggleQuarterUI(string uiName)  // string 으로 이름을 받고 해당 이름에 맞는 UI를 Active 한다.
    {
        switch (uiName)
        {
            case "Event":
                if (Gamemanager.GetInstance().start_event)
                {
                    cur_Quarter_UI_State = QuarterUIState.Event;
                    m_Quater_State_UI[0].SetActive(true);
                    m_Quater_State_UI[1].SetActive(false);
                    m_Quater_State_UI[2].SetActive(false);
                }
                break;
            case "EventEffect":
                cur_Quarter_UI_State = QuarterUIState.EventEffect;
                m_Quater_State_UI[0].SetActive(false);
                m_Quater_State_UI[1].SetActive(true);
                m_Quater_State_UI[2].SetActive(false);
                break;
            case "Result":
                cur_Quarter_UI_State = QuarterUIState.Result;
                m_Quater_State_UI[0].SetActive(false);
                m_Quater_State_UI[1].SetActive(false);
                m_Quater_State_UI[2].SetActive(true);
                break;
            default:
                Debug.Log("ToggleUI NameError");
                break;
        }
    }

    public void ChangeScene_Quarter()
    {
        if(Gamemanager.GetInstance().start_event)
        {
            Gamemanager.GetInstance().cal_evet();
            m_QuarterInfo_Update.SetComment();
            ToggleQuarterUI("Event");
            ToggleGameUI("Quarter");
        }
    }

    public void Ending_Scene()
    {
        if(Gamemanager.GetInstance().the_end)
        {
            ToggleGameUI("End");
        }
    }

    public void SelectSceneChange()
    {
        if (Gamemanager.GetInstance().now_member)
        {

            if (Gamemanager.GetInstance().now_member.work_type == member.type.Design)
            {
                cur_Select_UI_State = SelectUIState.Planner;
            }
            else if (Gamemanager.GetInstance().now_member.work_type == member.type.Programer)
            {
                cur_Select_UI_State = SelectUIState.Programmer;
            }
            else if(Gamemanager.GetInstance().now_member.work_type == member.type.Art)
            {
                cur_Select_UI_State = SelectUIState.Art;
            }
        }
    }

    public void ExPlain_On()
    {
        m_Explain_UI.SetActive(true);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
