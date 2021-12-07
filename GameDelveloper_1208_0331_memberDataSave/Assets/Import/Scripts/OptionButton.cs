using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    public OptionScript optionScript;
    public GameObject option;
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    public void SetMusic()
    {
        //효과음 비활성화
        optionScript.musicSet();
    }

    public void SetSound()
    {
        //배경음 비활성화
        optionScript.soundSet();
    }

    public void ExitOption()
    {
        option.gameObject.SetActive(false);
    }
}
