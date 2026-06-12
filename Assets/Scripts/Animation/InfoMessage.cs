using TMPro;
using UnityEngine;

public class InfoMessage : MonoBehaviour
{
    public static InfoMessage Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI _tmpGui;

    [SerializeField]
    private Animator _animator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideText()
    {
        Debug.Log("AAAAAAAA");
        _animator.SetTrigger("Hide");
    }

    public void ShowText(string text)
    {
        Debug.Log("CCCCCCCC");
        _tmpGui.text = text;
        Debug.Log("BBBBBBBB");
        _animator.SetTrigger("Show");
    }
}
