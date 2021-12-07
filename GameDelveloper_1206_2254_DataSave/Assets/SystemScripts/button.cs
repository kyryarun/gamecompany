using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public int work_number; //담당하는 업무 번호
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void retrun_number()
    {
        if (Gamemanager.GetInstance().now_member)
        {
            Gamemanager.GetInstance().now_member.select_work_number = work_number;
        }
    }
}
