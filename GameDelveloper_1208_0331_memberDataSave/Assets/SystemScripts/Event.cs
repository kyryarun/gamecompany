using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public int number_complete; //완성도 증가량
    public int number_fun; //재미 증가량
    public int number_tired; //피로도 증가량
    public string tooltip; //이벤트 설명
    public string tooltip1; //이벤트 설명
    public string tooltip2; //이벤트 설명
    public string tooltip3; //이벤트 설명
    public int number_percent; //이벤트 발동 확률

    private Event_list event_List;

    public void select_tooltip()
    {
        int num = UnityEngine.Random.Range(0, 3); //0,1,2 중 하나 선택.
        switch (num)
        {
            case 0:
                tooltip = tooltip1;
                break;
            case 1:
                tooltip = tooltip2;
                break;
            case 2:
                tooltip = tooltip3;
                break;
        }

    }

}
