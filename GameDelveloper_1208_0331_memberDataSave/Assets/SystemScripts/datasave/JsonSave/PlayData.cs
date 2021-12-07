using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


[Serializable]
public struct Character_Status_play
{
    public float Cur_Tired;  // 현재 피로도
    public bool isRetired; //리타이어 여부
}

[Serializable]
public class PlayData
{
    // 각 캐릭터의 게임 내 능력치 (게임 내에서 능력치의 증 감소가 존재할 때)
    // 재화
    public int Own_Coin;
    // 아이템 소지 개수
    public int Tired_Potion_1;
    public int Tired_Potion_2;
    public int Tired_Potion_3;
    public int Tired_Potion_4;
    // 현재 개발중인 게임의 완성도, 재미, 목표 완성도, 목표 재미
    /*
     *  난이도마다 게임의 필요 완성도와 재미가 달라짐.
     */
    public float Goal_Complete; //목표 완성도
    public float Goal_Fun; //목표 재미
    public float Cur_Complete; //현재 완성도
    public float Cur_Fun; //현재 재미

    // 현재 분기 or 일차
    public int boongi;  // 분기 영어로?
    public int Cur_Day;

    public List<Character_Status_play> character_Status_Plays; //플레이어 능력치의 리스트
}
