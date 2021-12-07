using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Perfection_Fun_LeanTween : MonoBehaviour
{
    public RectTransform m_Perfection_Back;
    public RectTransform m_Perfection_Bar;
    public TextMeshProUGUI m_Perfection_Text;

    public RectTransform m_Fun_Back;
    public RectTransform m_Fun_Bar;
    public TextMeshProUGUI m_Fun_Text;

    public void StartLeanTweenUI()
    {
        m_Perfection_Bar.sizeDelta = new Vector2(0, 150);
        m_Fun_Bar.sizeDelta = new Vector2(0, 150);
        Set_Perfection_UI();
        Set_Fun_UI();
    }

    public void Set_Perfection_UI()  // 완성도 정보 갱신
    {
        Gamemanager Manager = Gamemanager.GetInstance();

        float fRat = Manager.now_complete / Manager.goal_complete;  // 전체 비율 계산
        Vector2 vBGSize = m_Perfection_Back.sizeDelta;  // 각 UI바의 길이 구하기
        Vector2 vBarSize = m_Perfection_Bar.sizeDelta;
        vBarSize.x = vBGSize.x * fRat;  // 변경할 UI바의 길이.x의 값을 전체 길이에서 비율만큼 곱한 크기로 바꾸기
        //m_Perfection_Bar.sizeDelta = vBarSize;  // 변경할 UI바 길이 갱신하기
        LeanTween.size(m_Perfection_Bar, vBarSize, 1.2f);

        m_Perfection_Text.text = string.Format($"{Manager.now_complete}/{Manager.goal_complete}");  // 현재, 전체 수치 텍스트 갱신

        if (m_Perfection_Bar.sizeDelta.x > m_Perfection_Back.sizeDelta.x)  // Bar 의 크기가 Background 의 크기를 넘어가지 않도록 설정
        {
            m_Perfection_Bar.sizeDelta = m_Perfection_Back.sizeDelta;
        }
    }

    public void Set_Fun_UI()  // 완성도 정보 갱신
    {
        Gamemanager Manager = Gamemanager.GetInstance();

        float fRat = Manager.now_fun / Manager.goal_fun;  // 전체 비율 계산
        Debug.Log($"FUN UI 비율 : {fRat}");
        Vector2 vBGSize = m_Fun_Back.sizeDelta;  // 각 UI바의 길이 구하기
        Vector2 vBarSize = m_Fun_Bar.sizeDelta;
        vBarSize.x = vBGSize.x * fRat;  // 변경할 UI바의 길이.x의 값을 전체 길이에서 비율만큼 곱한 크기로 바꾸기
        //m_Fun_Bar.sizeDelta = vBarSize;  // 변경할 UI바 길이 갱신하기
        LeanTween.size(m_Fun_Bar, vBarSize, 1.2f);
        m_Fun_Text.text = string.Format($"{Manager.now_fun}/{Manager.goal_fun}");  // 현재, 전체 수치 텍스트 갱신

        if (m_Fun_Bar.sizeDelta.x > m_Fun_Back.sizeDelta.x)  // Bar 의 크기가 Background 의 크기를 넘어가지 않도록 설정
        {
            m_Fun_Bar.sizeDelta = m_Fun_Bar.sizeDelta;
        }
    }
}
