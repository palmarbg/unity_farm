using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent<int> OnFruitCountChanged;

    private int _fruitCounter = 0;

    private string _fileName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Delta time: {Time.deltaTime}");
    }

    private void FixedUpdate()
    {
        //Debug.Log($"Fixed delta time: {Time.fixedDeltaTime}");
    }

    private void IncreaseFruitCount()
    {
        _fruitCounter++;
        OnFruitCountChanged.Invoke(_fruitCounter);
    }

    private void OnEnable()
    {
        _fileName = Path.Combine(Application.persistentDataPath, "gamedata.json");
        Debug.Log(_fileName);

        var playerController = GameObject.FindFirstObjectByType<PlayerController>();
        playerController?.OnFruitPickedUp.AddListener(IncreaseFruitCount);

        LoadGameData();
    }

    private void OnDisable()
    {
        var playerController = GameObject.FindFirstObjectByType<PlayerController>();
        playerController?.OnFruitPickedUp.RemoveListener(IncreaseFruitCount);
    }

    private void OnDestroy()
    {
        SaveGameData();
    }

    private void SaveGameData()
    {
        var gameData = new GameData() { FruitCount = _fruitCounter };
        string jsonData = JsonUtility.ToJson(gameData);


        using (var writer = new StreamWriter(_fileName))
        {
            writer.Write(jsonData);
        }
    }

    private void LoadGameData()
    {
        if (!File.Exists(_fileName))
        {
            return;
        }

        string data;
        using (var reader = new StreamReader(_fileName))
        {
            data = reader.ReadToEnd();
        }

        var gameData = JsonUtility.FromJson<GameData>(data);
        _fruitCounter = gameData.FruitCount;

        OnFruitCountChanged.Invoke(_fruitCounter);
    }
}
