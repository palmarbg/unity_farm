using UnityEngine;

public class MoveRacingSheep : MoveRacingSheepBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward(Time.deltaTime * _speed);
    }
}
