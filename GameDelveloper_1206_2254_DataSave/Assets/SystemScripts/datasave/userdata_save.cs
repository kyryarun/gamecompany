using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userdata_save : MonoBehaviour
{
    public bool testb = false;
    public int testi = 1;
    // Start is called before the first frame update
    void Start()
    {
        testi = PlayerPrefs.GetInt("saveoni");
        if (PlayerPrefs.GetString("saveon") == "True")
        {
            testb = true;
        }
        else if (PlayerPrefs.GetString("saveon") == "False")
        {
            testb = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void data_save()
    {
        if (testb == false)
        {
            testb = true;
        }
        else
        {
            testb = false;
        }
        //playerprefs를 사용한 것. int, float, string으로 구분할 수 있다. 저장하기 및 불러오기가 가능하다.
        PlayerPrefs.SetString("saveon", testb.ToString());
        print(PlayerPrefs.GetString("saveon"));

        if (testi == 1)
        {
            testi = 2;
        }
        else
        {
            testi = 1;
        }
        PlayerPrefs.SetInt("saveoni", testi);
        print(PlayerPrefs.GetInt("saveoni"));
        
    }
}
