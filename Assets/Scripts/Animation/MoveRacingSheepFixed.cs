using UnityEngine;

public class MoveRacingSheepFixed : MoveRacingSheepBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        MoveForward(Time.fixedDeltaTime * _speed);
    }
}
