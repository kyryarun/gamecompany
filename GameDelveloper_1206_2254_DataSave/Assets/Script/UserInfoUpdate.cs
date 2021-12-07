    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInfoUpdate : MonoBehaviour
{
    public List<RectTransform> m_UserTired_Back;
    public List<RectTransform> m_UserTired_Bar;
    public List<TextMeshProUGUI> m_UserTired_Text;

    public RectTransform m_Now_Member_Back;
    public RectTransform m_Now_Member_Bar;
    public TextMeshProUGUI m_Now_UserTired_Text;
    public TextMeshProUGUI m_Success_Fail_Text;

    private void Start()
    {
        Init_Member_UI();
        //Set_UserInfo_UI();
    }

    // Update is called once per frame
    void Update()
    {
        Set_NowMember_Info();
    }

    public void Init_Member_UI()
    {
        for (int i = 0; i < m_UserTired_Bar.Count; i++)
        {
            m_UserTired_Bar[i].sizeDelta = new Vector2(0,100);  // 변경할 UI바 길이 갱신하기
            m_UserTired_Text[i].text = string.Format($"0/{Gamemanager.GetInstance().members[i].max_tired_parameter}");  // 현재, 전체 수치 텍스트 갱신
        }
    }

    public void Set_UserInfo_UI()  // 각 직군별 정보 갱신
    {
        for (int i = 0; i < m_UserTired_Bar.Count; i++)
        {
            Gamemanager Manager = Gamemanager.GetInstance();

            float fRat = Manager.members[i].tired_parameter / Manager.members[i].max_tired_parameter;  // 비율 계산
            Vector2 vBGSize = m_UserTired_Back[i].sizeDelta;  // 각 UI바의 길이 구하기
            Vector2 vBarSize = m_UserTired_Bar[i].sizeDelta;
            vBarSize.x = vBGSize.x * fRat;  // 변경할 UI바의 길이.x의 값을 전체 길이에서 비율만큼 곱한 크기로 바꾸기
            //m_UserTired_Bar[i].sizeDelta = vBarSize;  // 변경할 UI바 길이 갱신하기
            LeanTween.size(m_UserTired_Bar[i], vBarSize, 1.2f);

            if (Manager.members[i].tired_parameter < 0)
            {
                Manager.members[i].tired_parameter = 0;
            }

            m_UserTired_Text[i].text = string.Format($"{Manager.members[i].tired_parameter}/{Manager.members[i].max_tired_parameter}");  // 현재, 전체 수치 텍스트 갱신

            if (m_UserTired_Bar[i].sizeDelta.x > m_UserTired_Back[i].sizeDelta.x)  // Bar 의 크기가 Background 의 크기를 넘어가지 않도록 설정
            {
                m_UserTired_Bar[i].sizeDelta = m_UserTired_Back[i].sizeDelta;
            }
        }
    }

    public void Set_NowMember_Info()  // 현재 맴버의 피로도 UI 정보 갱신
    {
        Gamemanager Manager = Gamemanager.GetInstance();

        if (Gamemanager.GetInstance().pre_member)
        {
            float fRat = Manager.pre_member.tired_parameter / Manager.pre_member.max_tired_parameter;  // 비율 계산
            Vector2 vBGSize = m_Now_Member_Back.sizeDelta;  // 각 UI바의 길이 구하기
            Vector2 vBarSize = m_Now_Member_Bar.sizeDelta;
            vBarSize.x = vBGSize.x * fRat;  // 변경할 UI바의 길이.x의 값을 전체 길이에서 비율만큼 곱한 크기로 바꾸기
            m_Now_Member_Bar.sizeDelta = vBarSize;  // 변경할 UI바 길이 갱신하기
            m_Now_UserTired_Text.text = string.Format($"{Manager.pre_member.tired_parameter}/{Manager.pre_member.max_tired_parameter}");  // 현재, 전체 수치 텍스트 갱신

            if (m_Now_Member_Bar.sizeDelta.x > m_Now_Member_Back.sizeDelta.x)  // Bar 의 크기가 Background 의 크기를 넘어가지 않도록 설정
            {
                m_Now_Member_Bar.sizeDelta = m_Now_Member_Back.sizeDelta;
            }

            if (Gamemanager.GetInstance().pre_member.work_success)
            {
                m_Success_Fail_Text.text = string.Format("성공");
            }
            else
            {
                m_Success_Fail_Text.text = string.Format("실패");
            }
        }
    }

}
