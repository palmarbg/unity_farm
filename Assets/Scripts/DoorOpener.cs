using UnityEngine;
using UnityEngine.InputSystem;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Door _doorSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                _doorSystem.OpenOrClose();
            }
        }
    }
}
