using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryUI_Button : MonoBehaviour
{
    public int m_Scene = 0;

    private void Update()
    {
        Story_Progress();
    }

    public void Story_Progress()
    {
        if (UIManager.GetIntstance().cur_UI_State == UIManager.GameState.Story && Input.GetMouseButtonDown(0))
        {
            if (m_Scene < UIManager.GetIntstance().m_Story_State_UI.Count )
            {
                Change_Story_Scene(m_Scene);
                m_Scene++;
            }
            else
            {
                UIManager.GetIntstance().ToggleGameUI("GamePlay");
            }
        }
    }

    public void Change_Story_Scene(int number)
    {
        switch(number)
        {
            case 0:
                UIManager.GetIntstance().m_Story_State_UI[0].SetActive(true);
                UIManager.GetIntstance().m_Story_State_UI[1].SetActive(false);
                UIManager.GetIntstance().m_Story_State_UI[2].SetActive(false);
                break;
            case 1:
                UIManager.GetIntstance().m_Story_State_UI[0].SetActive(false);
                UIManager.GetIntstance().m_Story_State_UI[1].SetActive(true);
                UIManager.GetIntstance().m_Story_State_UI[2].SetActive(false);
                break;
            case 2:
                UIManager.GetIntstance().m_Story_State_UI[0].SetActive(false);
                UIManager.GetIntstance().m_Story_State_UI[1].SetActive(false);
                UIManager.GetIntstance().m_Story_State_UI[2].SetActive(true);
                break;
        }
    }
}
