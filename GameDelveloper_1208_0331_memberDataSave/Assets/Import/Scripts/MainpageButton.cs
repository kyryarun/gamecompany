using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainpageButton : MonoBehaviour
{
    public bool fadeOut; //페이드아웃 체크
    public float timer; 
    public Image fadeOutImage;
    public GameObject mainPageScene, optionScene;
    public bool isstart; //게임을 시작했는지 = 새 게임을 눌렀는지 판단
    public bool isexit; //게임을 종료했는지 = 마치기를 눌렀는지 판단

    Color color; //페이드아웃 계산용
    // Start is called before the first frame update
    void Start()
    {
        fadeOut = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // 페이드 아웃 시작, 시간 1초
        if (fadeOut && timer < 1f)
        {
            timer += Time.deltaTime;
            color.a = timer;
            fadeOutImage.color = color;
        }
        // 페이드 아웃 종료, 0.3초 대기
        else if (fadeOut && timer < 1.3f)
        {
            timer += Time.deltaTime;
        }
        // 메인 페이지 비활성화, 다음씬
        else if(fadeOut && timer >= 1.3f)
        {
            mainPageScene.gameObject.SetActive(false);
            if (isstart)
            {
                UIManager.GetIntstance().ToggleGameUI("Story"); //메인화면에서 게임화면 호출.  // 스토리 Scnene 으로 변경  모슨 스토리 확인 후 다음 누를 시 게임 플레이 이동
                color.a = 0;
                fadeOutImage.color = color;
                Init();
            }
            else if (isexit)
            {
                Application.Quit();
            }
        }
        if (color == null)
        {
            color = fadeOutImage.color;
        }
    }
    public void newGame()
    {
        //새게임 시작코드 추가
        isstart = true;
        fadeOut = true;
        
        //Debug.Log("New Game!");
    }
    public void option()
    {
        optionScene.gameObject.SetActive(true);
        //Debug.Log("Option!");
    }
    public void gallery()
    {
        //갤러리 기능 구현...ㅠ
        //fadeOut = true;
        //Debug.Log("Gallery!");
    }
    public void exit()
    {
        //게임 종료 코드
        isexit = true;
        fadeOut = true;
        //Debug.Log("Exit!");
    }

    public void Init()
    {
        isstart = false;
        fadeOut = false;
        timer = 0;
    }
}
