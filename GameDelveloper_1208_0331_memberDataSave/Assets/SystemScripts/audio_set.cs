using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_set : MonoBehaviour
{
    public GameObject camera; //카메라에 bgm관련이 있다.

    AudioSource audioSource; //bgm의 설정을 위한 컴포넌트

    public AudioClip main_bgm; //메인화면 bgm

    public AudioClip gameplay_bgm; //게임플레이 bgm

    public AudioClip ending_positive_bgm; //엔딩화면 승진, 근속 bgm.

    public AudioClip ending_negative_bgm; //엔딩화면 퇴사 bgm

    public PlayMusicOperator playMusic; //블로그의 음악재생기

    bool once;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource == null)
        {
            audioSource = camera.gameObject.GetComponent<AudioSource>();
        }
        //set_audio(main_bgm);
        if (once == false)
        {
            //set_name("main");
            once = true;
        }
    }


    public void set_audio(AudioClip audioClip) //상황에 맞춰서 오디오를 변경해 주어야한다.
    {
        audioSource.clip = audioClip;
        //메인화면에서의 bgm

        //게임플레이 중의 bgm

        //결과화면의 bmg
        //승진, 근속시의 bgm과 퇴사 시의 bgm을 구분해야한다.
    }

    public void set_name(string name)
    {
        playMusic.PlayBGM(name);
    }

    public void change_bgm_tomain()
    {
        playMusic.PlayBGM("main");
    }


    public void change_bgm_togame()
    {
        playMusic.PlayBGM("game");
    }

    public void change_bgm_togood()
    {
        playMusic.PlayBGM("good");
    }

    public void change_bgm_tobad()
    {
        playMusic.PlayBGM("bad");
    }

}
