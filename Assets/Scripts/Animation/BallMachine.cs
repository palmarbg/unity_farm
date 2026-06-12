using UnityEngine;

public class BallMachine : MonoBehaviour
{
    [SerializeField] private GameObject _tennisBallPrefab;

    [SerializeField] public float _timeInterval = 2.0f;
    [SerializeField] public float _ballSpeed = 10.0f;
    [SerializeField] public float _ballDeviation = .3f;
    [SerializeField] public float _ballLifeTime = 8.0f;

    float timer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= _timeInterval)
        {
            SpawnTennisBall();
            timer -= _timeInterval;
        }
    }

    void SpawnTennisBall()
    {
        // spawn object
        var ball = Instantiate(_tennisBallPrefab, transform.position, transform.rotation, transform);

        // set physics
        var rb = ball.GetComponent<Rigidbody>();
        //rb.position = transform.position;
        //rb.rotation = transform.rotation;
        rb.linearVelocity = _ballSpeed * (transform.forward + Random.insideUnitSphere * _ballDeviation);

        // set lifetime
        Destroy(ball, _ballLifeTime);
    }
}
