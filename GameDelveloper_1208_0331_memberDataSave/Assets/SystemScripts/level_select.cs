using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_select : MonoBehaviour
{
    public enum LEVEL { EASY, NORMAL, HARD }
    public LEVEL cur_level;
    // Start is called before the first frame update
    void Start()
    {
        cur_level = LEVEL.NORMAL; //기본 레벨은 노말모드.
    }

    // Update is called once per frame
    void Update()
    {
        update_level();
    }

    public void set_level(LEVEL level) //난이도버튼을 누르면 현재 레벨을 바꾸는 함수
        //난이도 변경시 다른곳에서 불려진다.
    {
        cur_level = level;
    }

    public void update_level()
    {
        switch (cur_level)
        {
            case LEVEL.EASY:
                easy_level();
                break;
            case LEVEL.NORMAL:
                normal_level();
                break;
            case LEVEL.HARD:
                hard_level();
                break;
        }
    }

    public void easy_level()
    {
        //이지일때 달라지는것들을 여기서 변경한다.
    }

    public void normal_level()
    {
        //노말은 게임의 기본이 되는 모드라서 변경하는게 적다
    }

    public void hard_level()
    {
        //하드는 보다 어려운 난이도이며 이지와 마찬가지로 변경점이 많다.
    }
}
