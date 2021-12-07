﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class GameData
{
    // 업적 or 엔딩 클리어 여부
    public bool isAcivment_1;
    public bool isAcivment_2;
    public bool isAcivment_3;
    public bool isAcivment_4;
    public bool isAcivment_5;
    public bool isAcivment_6;

    // 캐릭터 능력치
    public Character_Status Character_Status_1;  // 기획
    public Character_Status Character_Status_2;  // 프로그래머
    public Character_Status Character_Status_3;  // 프로그래머
    public Character_Status Character_Status_4;  // 아트
    public Character_Status Character_Status_5;  // 아트
}

[Serializable]
public struct Character_Status
{
    public enum Level { F, E, D, C, B, A, S };
    public Level Character_Level;  // 플레이어 등급
    public float Cur_Tired;  // 현재 피로도
    public float Max_tired;  // 최대 피로도
    public float Job_Ability;  // 업무 능력
    public float Event_Success_Per;  // 이벤트 성공 확률
    public float Character_Exp;  // 현재 경험치
    public float Character_Max_Exp;  // 레벨업에 필요한 경험치
}
