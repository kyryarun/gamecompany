using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class member : MonoBehaviour
{
    public float tired_parameter; //피로도를 나타내는 변수. 0일때 최상의 컨디션이다.
    public float max_tired_parameter; //최대 피로도 = 100
    public bool isretire; //리타이어 여부를 나타내는 변수. true일때 리타이어.
    public int select_work_number = -1; //선택한 업무의 번호.
    public int select_event_number = -1; //선택된 이벤트의 번호.
    public work next_work; //멤버가 실행할 일.
    public Event next_event; //멤버가 겪는 이벤트.
    public int number = -1; //업무의 난수를 의미한다.
    public int number_event = -1; //이벤트의 난수를 의미한다.
    public bool iswork; //각 업무마다 행동을 했는지 표시
    public bool work_success; //업무 성공
    public bool isevent; //분기마다 이벤트를 했는지 표시
    public int pn_number = -1; //이벤트 긍정 부정 표시
    public bool isRevied;

    public GameObject Tired_Max_Obj;
    public GameObject Now_member_Obj;
    public Text tired; //피로도 텍스트
    public Image myimage; //본인 이미지

    public Character_Status character_Status; //다음 게임으로 계승될 능력치. 게임이 종료될때까지 그 값의 변동이 없다.
    public Character_Status_play character_Status_play; //현재 게임에만 사용되는 능력치. 게임이 진행될수록 값이 바뀐다.

    public Rank rank;

    public enum type
    {
        Art,
        Design,
        Programer
    }

    public type work_type;


    //디버그 로그로 수치를 출력하도록 하기.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (next_work)
        {
            set_work();
        }
        tired_set();
        retire();
        //update_text();
        //update_image();
    }

    public void set_work() //팀원이 업무를 적용하는 부분
    {
        if (iswork == false)
        {
            number = Random.Range(0, 100); //100%를 의미한다.


            if (number < next_work.succes_percent) //성공시
            {
                Gamemanager.GetInstance().now_complete += next_work.increse_complete;
                Gamemanager.GetInstance().now_fun += next_work.increase_fun;
                tired_parameter += next_work.increase_tired_succes;
                work_success = true;
                Debug.Log(name + " 성공!");
                Debug.Log(name + "의 피로도 : " + tired_parameter);
                Debug.Log("현재 완성도 : " + Gamemanager.GetInstance().now_complete);
                Debug.Log("현재 재미 : " + Gamemanager.GetInstance().now_fun);
                Gamemanager.GetInstance().audio_Setting.playMusic.PlaySFC("success");
            }
            else
            {
                tired_parameter += next_work.increase_tired_fail;
                Debug.Log(name + " 실패");
                Debug.Log(name + "의 피로도 : " + tired_parameter);
                Debug.Log("현재 완성도 : " + Gamemanager.GetInstance().now_complete);
                Debug.Log("현재 재미 : " + Gamemanager.GetInstance().now_fun);
                Gamemanager.GetInstance().audio_Setting.playMusic.PlaySFC("fail");
            }
            pre_save_data();
            iswork = true;
            Gamemanager.GetInstance().pre_member = this;
            Gamemanager.GetInstance().now_member = null;

            UIManager.GetIntstance().m_UserInfo_Update.Set_NowMember_Info();
        }
    }

    public void select_event() //이벤트를 무엇을 할지 정함.
    {
        pn_number = -1; //긍정적, 부정적의 판단
        if (isevent == false)
        {
            number_event = Random.Range(0, 100); //99 = 100%를 의미한다.

            if (tired_parameter <= number_event)
            {
                pn_number = 1;
                if (tired_parameter <= 29)
                {
                    select_event_number = 1;
                }
                else if (tired_parameter <= 69)
                {
                    select_event_number = 2;
                }
                else if (tired_parameter <= 99)
                {
                    select_event_number = 3;
                }
                else
                {
                    select_event_number = 4;

                }
            }
            else
            {
                number_event = Random.Range(0, 100); //새로 난수생성
                if (tired_parameter >= number_event)
                {
                    pn_number = 0;
                    if (tired_parameter <= 24)
                    {
                        select_event_number = 1;
                    }
                    else if (tired_parameter <= 49)
                    {
                        select_event_number = 2;
                    }
                    else if (tired_parameter <= 74)
                    {
                        select_event_number = 3;
                    }
                    else if (tired_parameter <= 99)
                    {
                        select_event_number = 4;
                    }
                }
            }

            isevent = true;
        }
    }

    public void set_event()
    {
        if (isretire == false)
        {
            Debug.Log(name);
            if (pn_number == -1)
            {
                Debug.Log("아무일도 일어나지 않았다.");
            }
            else if (pn_number == 0)
            {
                Gamemanager.GetInstance().total_event++;
                Debug.Log("긍정적인 이벤트가 발생했다.");
            }
            else if (pn_number == 1)
            {
                Gamemanager.GetInstance().total_event++;
                Debug.Log("부정적인 이벤트가 발생했다.");
            }
            Gamemanager.GetInstance().now_complete += next_event.number_complete;
            Gamemanager.GetInstance().now_fun += next_event.number_fun;
            tired_parameter += next_event.number_tired;
            Debug.Log(name + "의 피로도 : " + tired_parameter);
        }
        else
        {
            int number = Random.Range(0, 100);
            if (number < Gamemanager.GetInstance().event_List.event_List[25].number_percent)
            {
                isRevied = true;
                Gamemanager.GetInstance().total_event++;
                tired_parameter = 50;
                isretire = false;
                iswork = true;
                Tired_Max_Obj.SetActive(false);
                Debug.Log("부활했다.");
            }
            else
            {
                isRevied = false;
            }
        }
    }

    public void retire()
    {
        if (tired_parameter >= 100) //피로도가 100이되면 리타이어된다.
        {
            tired_parameter = 100;
            isretire = true;
            Tired_Max_Obj.SetActive(true);
        }
        pre_save_data();
    }

    public void Init()  // 이벤트 이후 업무 초기화
    {
        select_work_number = -1;
        select_event_number = -1;
        iswork = false;
        isevent = false;
        next_work = null;
        next_event = null;
        work_success = false;
        isRevied = false;
    }

    //public void update_text()
    //{
    //    tired.text = tired_parameter.ToString() + " / " + max_tired_parameter.ToString();
    //}

    public void update_image()
    {
        if (myimage)
        {
            Color color = myimage.GetComponent<Color>();
            if (isevent == false)
            {
                if (iswork)
                {
                    color.a = 0.5f;
                    color = Color.gray;
                }
                else
                {
                    color.a = 1;
                    color = Color.white;
                }
            }
        }
    }

    public void tired_set()
    {
        if (tired_parameter < 0)
        {
            tired_parameter = 0;
        }
    }

    public void pre_save_data()
    {
        character_Status_play.Cur_Tired = tired_parameter;
        character_Status_play.isRetired = isretire;
    }

    public void after_load_data()
    {
        tired_parameter = character_Status_play.Cur_Tired;
        isretire = character_Status_play.isRetired;
    }
}
