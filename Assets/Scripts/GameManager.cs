using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private int _fruitCounter = 0;

    public UnityEvent<int> OnFruitCountChanged;

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
        var playerController = GameObject.FindFirstObjectByType<PlayerController>();
        playerController?.OnFruitPickedUp.AddListener(IncreaseFruitCount);
    }

    private void OnDisable()
    {
        var playerController = GameObject.FindFirstObjectByType<PlayerController>();
        playerController?.OnFruitPickedUp.RemoveListener(IncreaseFruitCount);
    }
}
