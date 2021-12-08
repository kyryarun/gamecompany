using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public string GameData_FilePath;
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }

    static DataManager _instance;
    public static DataManager Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "DataController";
                _instance = _container.AddComponent(typeof(DataManager)) as DataManager;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }

    public string GameDataFileName = "GameData.json";

    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if (_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }

    private void Awake()
    {
        GameData_FilePath = Application.persistentDataPath + GameDataFileName;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Data Path : {Application.persistentDataPath}");
        LoadGameData();
        SaveGameData();
    }

    public void LoadGameData()
    {
        if (File.Exists(GameData_FilePath))
        {
            Debug.Log("불러오기 성공");
            string FromJsonData = File.ReadAllText(GameData_FilePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else
        {
            Debug.Log("새로운 파일 생성");
            _gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);

        File.WriteAllText(GameData_FilePath, ToJsonData);
        Debug.Log("저장완료");
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}
