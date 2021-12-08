using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class distrator : MonoBehaviour, IPointerDownHandler
{
    public int distractor_number; //선택지가 가지고 있는 번호. 이것으로 어떤 선택지를 골랐는지 판단한다.
    //선택지에 따른 효과도 여기에 저장할지 고민.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int retrun_choice() //클릭한 다음 그 값을 전달하는 함수.
    {
        return distractor_number;
    }

    public void OnPointerDown(PointerEventData eventData) //해당 영역에서 클릭해야 작동한다.
    {
        Gamemanager.GetInstance().distrator_Manager.choice_number = retrun_choice(); //여기서 값을 전달한다.
        Debug.Log("클릭했다");
    }
}
