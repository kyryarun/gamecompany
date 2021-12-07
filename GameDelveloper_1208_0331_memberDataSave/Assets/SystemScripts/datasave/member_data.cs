using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class member_data : MonoBehaviour
{
    public PlayDataManager playDatamanager;
    public DataManager dataManager;


    //데이터는 두종류로 구분한다.
    //1번은 다음판으로 넘어가는 데이터. 이후 game 데이터
    //2번은 현재 판에서만 사용하는 데이터. 이후 play 데이터
    //멤버는 game과 play 모두 가지고 있기 때문에 따로 저장과 불러오기를 만들었다.
    //최초 실행시 (데이터가 없는 경우) 로드를 하면 오류가 생기는데 원인불명
    
    //game데이터의 종류 : 멤버들의 등급, 능력치
    //play데이터의 종류 : 멤버들의 현재 체력, 리타이어 여부
    //리스트를 사용하여 각 멤버들에게 접근하도록 하였다.

    // Start is called before the first frame update
    void Start()
    {
        playDatamanager = PlayDataManager.Play_Instance;
        dataManager = DataManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //game부분의 멤버데이터 관리
    public void gamedata_set()
    {
        dataManager.gameData.ranks = new List<Rank>(5);
        dataManager.gameData.character_Statuses = new List<Character_Status>(5);
        for (int i = 0; i < Gamemanager.GetInstance().members.Count; i++)
        {
            dataManager.gameData.ranks.Add(Gamemanager.GetInstance().members[i].rank);
            dataManager.gameData.character_Statuses.Add(Gamemanager.GetInstance().members[i].character_Status);
        }
        gamedata_save();
    }

    public void gamedata_save()
    {
        for (int i = 0; i < Gamemanager.GetInstance().members.Count; i++)
        {
            dataManager.gameData.ranks[i] = (Gamemanager.GetInstance().members[i].rank);
            dataManager.gameData.character_Statuses[i] = (Gamemanager.GetInstance().members[i].character_Status);
        }
        dataManager.SaveGameData();
        Debug.Log("게임 데이터 저장 성공");
    }

    public void gamedata_load()
    {
        dataManager.LoadGameData();

        for (int i = 0; i < Gamemanager.GetInstance().members.Count; i++)
        {
            (Gamemanager.GetInstance().members[i].rank) = dataManager.gameData.ranks[i];
            (Gamemanager.GetInstance().members[i].character_Status) = dataManager.gameData.character_Statuses[i];
        }

        Debug.Log("게임 데이터 로드 성공");
    }


    //play부분의 멤버데이터 관리
    public void playdata_set() //최초 데이터 리스트 생성. playdata의 리스트를 생성하는 부분이다. 저장하는 부분과는 별개.
    {
        playDatamanager.playData.character_Status_Plays = new List<Character_Status_play>(5);
        for (int i = 0; i < Gamemanager.GetInstance().members.Count; i++)
        {
            playDatamanager.playData.character_Status_Plays.Add(Gamemanager.GetInstance().members[i].character_Status_play);
        }
        playdata_save();
    }

    public void playdata_save() //리스트에 데이터를 넣는 부분. 실제로 저장한다.
    {
        for (int i = 0; i < Gamemanager.GetInstance().members.Count; i++)
        {
            playDatamanager.playData.character_Status_Plays[i] = (Gamemanager.GetInstance().members[i].character_Status_play);
        }

        playDatamanager.SaveGameData();
        Debug.Log("게임 플레이 저장 성공");
    }

    public void playdata_load()
    {
        playDatamanager.LoadGameData();

        for (int i = 0; i < Gamemanager.GetInstance().members.Count; i++)
        {
           // Debug.Log(i + "번 이전" + Gamemanager.GetInstance().members[i].character_Status_play.Cur_Tired);
            //Gamemanager.GetInstance().members[i].character_Status_play.Cur_Tired = playDatamanager.playData.character_Status_Plays[i].Cur_Tired;
            //Debug.Log(i + "번" + playDatamanager.playData.character_Status_Plays[i].Cur_Tired);
            //Debug.Log(i + "번 이후" + Gamemanager.GetInstance().members[i].character_Status_play.Cur_Tired);
            //Gamemanager.GetInstance().members[i].character_Status_play.isRetired = playDatamanager.playData.character_Status_Plays[i].isRetired;

            Gamemanager.GetInstance().members[i].character_Status_play = playDatamanager.playData.character_Status_Plays[i];
            Gamemanager.GetInstance().members[i].after_load_data();
        }
        Debug.Log("게임 플레이 로드 성공");
    }


}
