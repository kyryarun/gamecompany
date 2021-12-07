using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionScript : MonoBehaviour
{
    public bool sound, music;
    public GameObject soundImg, musicImg;
    // Start is called before the first frame update
    void Start()
    {
        sound = true; //효과음이랑 배경음 쓸 때 이 변수 쓰시면 될 듯 함다
        music = true;
    }

    // Update is called once per frame
    void Update() {}

    public void musicSet()
    {
        if (music)
        {
            musicImg.SetActive(false);
            music = false;
        }
        else
        {
            musicImg.SetActive(true);
            music = true;
        }
    }
    public void soundSet()
    {
        if (sound)
        {
            soundImg.SetActive(false);
            sound = false;
        }
        else
        {
            soundImg.SetActive(true);
            sound = true;
        }
    }
}
