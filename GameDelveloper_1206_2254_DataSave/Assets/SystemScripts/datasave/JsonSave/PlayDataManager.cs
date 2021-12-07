using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayDataManager : MonoBehaviour
{
    static GameObject _Play_container;
    static GameObject Play_Container
    {
        get
        {
            return _Play_container;
        }
    }

    static PlayDataManager _Play_instance;
    public static PlayDataManager Play_Instance
    {
        get
        {
            if (!_Play_instance)
            {
                _Play_container = new GameObject();
                _Play_container.name = "DataController";
                _Play_instance = _Play_container.AddComponent(typeof(PlayDataManager)) as PlayDataManager;
                DontDestroyOnLoad(_Play_container);
            }
            return _Play_instance;
        }
    }

    public string GameDataFileName = "GamePlayData.json";

    public PlayData _playData;
    public PlayData playData
    {
        get
        {
            if (_playData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _playData;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Data Path : {Application.persistentDataPath}");
        //LoadGameData();
        //SaveGameData();
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;

        if (File.Exists(filePath))
        {
            Debug.Log("불러오기 성공");
            string FromJsonData = File.ReadAllText(filePath);
            _playData = JsonUtility.FromJson<PlayData>(FromJsonData);
        }
        else
        {
            Debug.Log("새로운 파일 생성");
            _playData = new PlayData();
        }
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(playData);
        string filepath = Application.persistentDataPath + GameDataFileName;

        File.WriteAllText(filepath, ToJsonData);
        Debug.Log("저장완료");
    }

    public bool DeleteGameData()  // filePath 에 해당하는 데이터 삭제 (삭제 완료시 True 반환)
    {
        string filePath = Application.persistentDataPath + GameDataFileName;
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            return true;
        }
        return false;
    }

    public bool PlayFileCheck()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;
        if (File.Exists(filePath))
        {
            return true;
        }
        return false;
    }

    private void OnApplicationQuit()
    {
        //SaveGameData();
    }
}