using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScene : MonoBehaviour
{
    public int survived, eventNum;
    public float Perfection, howFun;
    //public TextMeshProUGUI sur, eve, per, fun;
    float timer;

    bool isset; 
    // Start is called before the first frame update
    void Start()
    {
        //변수 4개 값 임시로 설정한 부분임다 지우셔도 됨다
        
        
        // 스크립트로 만들어진 텍스트 폰트 변경
    }

    // Update is called once per frame
    void Update()
    {
        ////가능하면 나중에 하나씩 뜨는 코드 추가
        //if (Gamemanager.GetInstance().the_end)
        //{
        //    if (isset == false)
        //    set_number();
        //}
    }

    //void set_number()
    //{
    //    sur.text += survived;
    //    eve.text += eventNum;
    //    per.text += Perfection;
    //    fun.text += howFun;
    //    isset = true;
    //}
}
