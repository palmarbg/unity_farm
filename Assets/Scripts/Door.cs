using UnityEngine;
using UnityEngine.Assertions;

public class Door : MonoBehaviour
{
    private enum State
    {
        Open,
        Opening,
        Closed,
        Closing
    }

    private State _state = State.Closed;

    [SerializeField] private float _openingSpeed = 90;
    [SerializeField] private Transform _door;


    private readonly Quaternion _closedRotation = Quaternion.Euler(new(0, 0, 0));
    private readonly Quaternion _openRotation = Quaternion.Euler(new(0, 90, 0));

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_state == State.Opening)
        {
            _door.rotation = Quaternion.RotateTowards(_door.rotation, _openRotation, _openingSpeed * Time.deltaTime);
            if (Quaternion.Angle(_door.rotation, _openRotation) < .001)
            {
                _state = State.Open;
            }
        }

        if (_state == State.Closing)
        {
            _door.rotation = Quaternion.RotateTowards(_door.rotation, _closedRotation, _openingSpeed * Time.deltaTime);
            if (Quaternion.Angle(_door.rotation, _closedRotation) < .001)
            {
                _state = State.Closed;
            }
        }
    }

    public void Open()
    {
        Assert.IsTrue(_state == State.Closed);
        if (_state == State.Closed)
        {
            _state = State.Opening;
        }
    }
    public void Close()
    {
        Assert.IsTrue(_state == State.Open);
        if (_state == State.Open)
        {
            _state = State.Closing;
        }
    }
    public void OpenOrClose()
    {
        if (_state == State.Closed)
        {
            Open();
        }
        else if (_state == State.Open)
        {
            Close();
        }
    }
}
