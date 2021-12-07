using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScript : MonoBehaviour
{
    public GameObject stamp, stamp1, stamp2, stamp3;
    public GameObject endScene, resultScript;
    public GameObject postit;
    public TextMeshProUGUI reason, postitText;
    public float Perfection, howFun;                    //정확도, 재미
    public float goal_per;                              //목표 정확도
    public float goal_fun;                              //목표 재미
    float timer;
    string PS, clear;                                 //포스트잇 추신, 승진 여부
    bool stampSet, setOver;                           //스템프 및 스템프 세팅 여부

    public bool set_on; //최초 세팅 준비 여부
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (set_on == false)
        {
            first_setting();
        }
        else
        {
            view_result();
        }
    }

    public void first_setting()
    {
        //변수선언
        stampSet = false;
        setOver = false;
        //Perfection = 80;
        //howFun = 80;
        PS = PSSelect();

        //승진, 권직, 퇴사 값 설정
        if (Perfection >= goal_per && howFun >= goal_fun)
        {
            clear = "승진";
            Gamemanager.GetInstance().audio_Setting.change_bgm_togood();
            stamp = stamp1;
        }
        else if ((Perfection >= goal_per && howFun >= 40) || (Perfection >= 80 && howFun >= goal_fun))
        {
            clear = "권직";
            Gamemanager.GetInstance().audio_Setting.change_bgm_togood();
            stamp = stamp2;
        }
        else
        {
            clear = "퇴사";
            Gamemanager.GetInstance().audio_Setting.change_bgm_tobad();
            stamp = stamp3;
        }
        //발령사유 텍스트 변경
        if (reason) reason.text = "■ 발령 사유 : " + clear;

        set_on = true;
    }

    public void view_result()
    {
        //대기화면에서 마우스 클릭시 엔딩 팝업 활성화 및 결과창 스크립트 비활성화
        if (setOver && Input.GetMouseButtonDown(0))
        {
            endScene.gameObject.SetActive(true);
            //resultScript.gameObject.SetActive(false);
        }
        //엔딩 화면 후 3초 이상, 포스트잇 활성화 및 마우스 클릭 대기
        if (timer > 3 && !setOver)
        {
            postit.gameObject.SetActive(true);
            postitText.text += PS;
            setOver = true;
        }
        //엔딩 화면 후 1.5~3초까지 타이머 증가, 스탬프 활성화
        else if (timer > 1.5)
        {
            if (!stampSet)
            {
                stamp.SetActive(true);
                stampSet = true;
            }
            timer += Time.deltaTime;
        }
        //엔딩 화면 후 1.5초까지 타이머 증가
        else timer += Time.deltaTime;
    }
    string PSSelect()
    {
        if (Gamemanager.GetInstance().retire_number < Gamemanager.GetInstance().retire_limit)
        {
            if (Perfection >= goal_per)
            {
                if (howFun >= goal_fun) return "우리 게임이 불티나게\n팔리고있다!\n해냈다 우리팀!!!";
                else if (howFun >= 40) return "게임은 완성되었다...\n애매한 매출을 내고 있지만\n다 만들었단 것에 의의를\n두자";
                else if (howFun < 40) return "게임이 완성되었지만\n출시가 되기도 전에\n프로젝트가 잘렸다...";
            }
            else if (Perfection >= 80)
            {
                if (howFun >= goal_fun) return "게임이 완성되지 않았지만\n프로젝트를 눈여겨봐\n장기간의 프로젝트가\n될 수 있었다.";
                else if (howFun >= 40) return "게임이 완성되지 않았다...\n그다지 반응도 좋지 않네...\n좀더 열심히 만들어 볼걸...";
                else if (howFun < 40) return "우리 게임을 본 회사는\n더이상 말이 없었다...\n이거 망했네..";
            }
            else
            {
                if (howFun >= goal_fun) return "재미가 있으면 뭐해!\n완성이 되지 않았는데!";
                else if (howFun >= 40) return "회사 내에서 우리팀의\n이미지가 좋지 않다...\n한동안 프로젝트는 없겠네..";
                else if (howFun < 40) return "다른 직업을 알아볼\n때인 것 같다...";
            }
        }
        else
        {
            return "팀원이 쓰러져서 게임을 더이상 만들 수 없다...";
        }
            
        return "결국 윤곽조차\n만들어내지 못했다.";
    }

    public void Init()
    {
        setOver = false;
        set_on = false;
        stamp.SetActive(false);
        postit.gameObject.SetActive(false);
        postitText.text = null;
        timer = 0;
    }
}
