using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuarterInfoUpdate : MonoBehaviour
{
    public List<TextMeshProUGUI> Event_Comment;
    public List<TextMeshProUGUI> Event_Effect_Comment;

    public void SetComment()
    {
        if (Gamemanager.GetInstance().start_event)
        {
            for (int i = 0; i < Event_Comment.Count; i++)
            {
                Gamemanager.GetInstance().members[i].next_event.select_tooltip();
                Event_Comment[i].text = string.Format($"{Gamemanager.GetInstance().members[i].next_event.tooltip}");
            }
        }
    }

    public void SetEffectComment()
    {
        Gamemanager Manager = Gamemanager.GetInstance();

        if (Manager.start_event)
        {
            string EffectComment = null;
            for (int i = 0; i < Event_Effect_Comment.Count; i++)
            {

                if (Manager.members[i].next_event.number_fun != 0)
                {
                    EffectComment += string.Format($"재미:{Gamemanager.GetInstance().members[i].next_event.number_fun} ");
                }
                if (Manager.members[i].next_event.number_complete != 0)
                {
                    EffectComment += string.Format($"완성도:{Gamemanager.GetInstance().members[i].next_event.number_complete} ");
                }
                if (Manager.members[i].next_event.number_tired != 0)
                {
                    EffectComment += string.Format($"피로도:{Gamemanager.GetInstance().members[i].next_event.number_tired} ");
                }

                if(Manager.members[i].next_event.number_fun == 0 && Manager.members[i].next_event.number_complete == 0 && Manager.members[i].next_event.number_tired == 0)
                {
                    if (Manager.members[i].isRevied)
                    {
                        EffectComment = "팀원이 부활했다!";
                    }
                    else
                    {
                        EffectComment = "아무일도 일어나지 않았다.";
                    }
                }

                Event_Effect_Comment[i].text = EffectComment;
                EffectComment = null;
            }
        }

    }
}
