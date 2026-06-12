using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateFruitCountText(int count)
    {
        foreach (var child in GetComponentsInChildren<Transform>(true))
        {
            if (child.CompareTag("Counter"))
            {
                var counterLabel = child.GetComponent<TextMeshProUGUI>();
                counterLabel.text = count.ToString();
                break;
            }
        }
    }

    private void OnEnable()
    {
        var gameManager = GameObject.FindFirstObjectByType<GameManager>();
        gameManager?.OnFruitCountChanged.AddListener(UpdateFruitCountText);
    }

    private void OnDisable()
    {
        var gameManager = GameObject.FindFirstObjectByType<GameManager>();
        gameManager?.OnFruitCountChanged.RemoveListener(UpdateFruitCountText);
    }
}
