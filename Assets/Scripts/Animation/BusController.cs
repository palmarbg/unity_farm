using System.Collections;
using UnityEngine;

public class BusController : MonoBehaviour
{
    [SerializeField]
    private float _maxSpeed = 2.0f;

    [SerializeField]
    private float _acceleration = 0.5f;

    private float _speed;
    private BusMovingState _state = BusMovingState.DriveToStop;

    private enum BusMovingState
    {
        SpeedUp, SlowDown, DriveToStop, LeaveStop
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = _maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (_state == BusMovingState.SpeedUp || _state == BusMovingState.LeaveStop)
        {
            _speed = Mathf.Min(_maxSpeed, _speed + _acceleration * Time.deltaTime);
            if (_speed == _maxSpeed)
            {
                _state = BusMovingState.DriveToStop;
            }
        }
        else if (_state == BusMovingState.SlowDown)
        {
            if (_speed > 0 && _speed <= _acceleration * Time.deltaTime)
            {
                // trigger once stopping
                // would be better to add a new state to indicate waiting
                StartCoroutine(WaitForBusLeave());
            }
            _speed = Mathf.Max(0, _speed - _acceleration * Time.deltaTime);
        }

        if (!(_state == BusMovingState.SlowDown && _speed == 0.0f))
        {
            int maxPos = 45;
            Vector3 newPosition = new Vector3(
                (transform.position.x - _speed * Time.deltaTime + 3 * maxPos) % (2 * maxPos) - maxPos,
                transform.position.y,
                transform.position.z
                );

            transform.position = newPosition;
        }
    }

    IEnumerator WaitForBusLeave()
    {
        yield return new WaitForSeconds(5);
        _state = BusMovingState.LeaveStop;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BusStop"))
        {
            _state = BusMovingState.SlowDown;
        }
    }
}

