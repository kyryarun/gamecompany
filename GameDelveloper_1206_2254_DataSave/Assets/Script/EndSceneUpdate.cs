using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneUpdate : MonoBehaviour
{
    public List<TextMeshProUGUI> EndSceneText;


    public void SetEndText()
    {
        EndSceneText[0].text = string.Format($"완성도 : {Gamemanager.GetInstance().now_complete}");
        EndSceneText[1].text = string.Format($"재미 : {Gamemanager.GetInstance().now_fun}");
        EndSceneText[2].text = string.Format($"생존 팀원 : {Gamemanager.GetInstance().save_number}");
        EndSceneText[3].text = string.Format($"이벤트 발생 : {Gamemanager.GetInstance().total_event}");
    }

}
