using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager instance;

    public AudioSource m_BGM_Source;
    public AudioSource m_Effect_Source;

    public List<AudioClip> BGM_List;
    public List<AudioClip> Effect_List;

    static SoundManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
