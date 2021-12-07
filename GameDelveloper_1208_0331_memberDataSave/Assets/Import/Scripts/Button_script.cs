using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_script : MonoBehaviour
{
    public GameObject resultScene, endScene;
    void Start() {}

    void Update() {}
    public void backToMain()
    {
        //메인메뉴로 돌아가는 코드 추가, 가능하면 페이드아웃
        resultScene.gameObject.SetActive(false);
        Gamemanager.GetInstance().resultScript.Init();
        endScene.gameObject.SetActive(false);
        Gamemanager.GetInstance().gameplay_UI.SetActive(false); //이게 지금 안먹힌다.
        Gamemanager.GetInstance().mainpageButton.gameObject.SetActive(true);
        UIManager.GetIntstance().ToggleGameUI("GamePlay");
        Debug.Log("메인화면");
    }
    public void reTry()
    {
        //재시작 코드 추가, 가능하면 페이드아웃
        resultScene.gameObject.SetActive(false);
        Gamemanager.GetInstance().resultScript.Init();
        endScene.gameObject.SetActive(false);

        Debug.Log("게임 재시작");
    }
}
