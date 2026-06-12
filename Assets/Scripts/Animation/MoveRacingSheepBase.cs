using UnityEngine;

public class MoveRacingSheepBase : MonoBehaviour
{
    [SerializeField] protected float _speed = 3.0f;

    private Vector3 _startingPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        _startingPosition = transform.position;
    }

    protected void MoveForward(float distance)
    {
        transform.Translate(transform.forward * distance, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.ToLower().Contains("fence"))
        {
            transform.position = _startingPosition;
        }
    }
}
