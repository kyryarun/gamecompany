using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOperator : MonoBehaviour
{
    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }

    // Inspector에 표시할 배경음악 목록
    public BgmType[] BGMList;
    public BgmType[] SFCList;

    private AudioSource BGM;
    private AudioSource SFC;
    
    private string NowBGMname = "";
    private string NowSFCname = "";

    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.loop = true;
        if (BGMList.Length > 0) PlayBGM(BGMList[0].name);

        SFC = gameObject.AddComponent<AudioSource>();
        SFC.loop = false;
        if (SFCList.Length > 0) PlayBGM(SFCList[0].name);
    }

    private void Update()
    {
        update_volum();
    }

    public void PlayBGM(string name)
    {
        if (NowBGMname.Equals(name)) return;

        for (int i = 0; i < BGMList.Length; ++i)
            if (BGMList[i].name.Equals(name))
            {
                BGM.clip = BGMList[i].audio;
                BGM.Play();
                NowBGMname = name;
            }
    }

    public void PlaySFC(string name)
    {
        for (int i = 0; i < SFCList.Length; ++i)
            if (SFCList[i].name.Equals(name))
            {
                SFC.clip = SFCList[i].audio;
                SFC.Play();
                SFC.PlayOneShot(SFCList[i].audio);
                NowSFCname = name;
            }
    }

    public void update_volum()
    {
        if (Gamemanager.GetInstance().optionScript.music == true)
        {
            BGM.mute = false;
        }
        else
        {
            BGM.mute = true;
        }

        if (Gamemanager.GetInstance().optionScript.sound == true)
        {
            SFC.mute = false;
        }
        else
        {
            SFC.mute = true;
        }
    }
}