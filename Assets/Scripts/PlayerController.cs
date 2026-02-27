using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 10.0f;

    [SerializeField]
    private float _rotationSpeed = 280.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            transform.parent.Translate(Vector3.forward * Time.deltaTime * _movementSpeed, Space.Self);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            transform.parent.Translate(Vector3.back * Time.deltaTime * _movementSpeed, Space.Self);
        }
        if (Keyboard.current.aKey.isPressed)
        {
            transform.parent.Rotate(Vector3.down, Time.deltaTime * _rotationSpeed, Space.Self);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.parent.Rotate(Vector3.up, Time.deltaTime * _rotationSpeed, Space.Self);
        }
    }
}
