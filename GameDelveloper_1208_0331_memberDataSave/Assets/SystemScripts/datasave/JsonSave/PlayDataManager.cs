using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayDataManager : MonoBehaviour
{
    public string PlayData_FilePath;
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
                SaveGameData();
            }
            return _playData;
        }
    }

    private void Awake()
    {
        PlayData_FilePath = Application.persistentDataPath + GameDataFileName;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Data Path : {Application.persistentDataPath}");
    }

    public bool LoadGameData()
    {
        if (File.Exists(PlayData_FilePath))
        {
            Debug.Log("불러오기 성공");
            string FromJsonData = File.ReadAllText(PlayData_FilePath);
            _playData = JsonUtility.FromJson<PlayData>(FromJsonData);
            return true;
        }
        else
        {
            Debug.Log("불러오기 실패");
            return false;
        }
    }

    public void SaveGameData()
    {
        if (File.Exists(PlayData_FilePath))
        {
            string ToJsonData = JsonUtility.ToJson(playData);

            File.WriteAllText(PlayData_FilePath, ToJsonData);
            Debug.Log("저장완료");
        }
        else
        {
            _playData = new PlayData();
            string ToJsonData = JsonUtility.ToJson(playData);

            File.WriteAllText(PlayData_FilePath, ToJsonData);
        }
    }

    public bool DeleteGameData()  // filePath 에 해당하는 데이터 삭제 (삭제 완료시 True 반환)
    {
        if (File.Exists(PlayData_FilePath))
        {
            File.Delete(PlayData_FilePath);
            return true;
        }
        return false;
    }

    public bool PlayFileCheck()
    {
        if (File.Exists(PlayData_FilePath))
        {
            return true;
        }
        return false;
    }
}