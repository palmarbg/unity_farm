using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // why public??
    [SerializeField] private float _width = 5.0f;
    [SerializeField] private float _length = 5.0f;
    [SerializeField] private int _numberOfObjectsToSpawn = 6;

    [SerializeField] private SpawnableSO _spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < _numberOfObjectsToSpawn; i++)
        {
            GameObject child = Instantiate(_spawner.GetRandomGameObject(), transform);

            child.transform.position = transform.TransformPoint(
                    new Vector3(
                        Random.Range(-_width, _width),
                        0,
                        Random.Range(-_length, _length)
                    )
                );
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnDrawGizmos()
    {
        Vector3 center = transform.position;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLineStrip(new(new[]{
            center - new Vector3( _width, 0, -_length),
            center - new Vector3( _width, 0,  _length),
            center - new Vector3(-_width, 0,  _length),
            center - new Vector3(-_width, 0, -_length)
            }), true);
    }
}
