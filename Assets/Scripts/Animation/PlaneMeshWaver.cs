using UnityEngine;

public class PlaneMeshWaver : MonoBehaviour
{
    [SerializeField]
    float _amplitude = .1f;

    [SerializeField]
    float _frequency = 2 * Mathf.PI / 2;

    [SerializeField]
    float _waveNumberX = 3;

    [SerializeField]
    float _waveNumberZ = 2;

    private Vector3[] _vertices;
    private MeshFilter _meshFilter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _vertices = _meshFilter.mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _vertices.Length; i++)
        {
            Vector3 v = _vertices[i];
            _vertices[i].y = _amplitude * Mathf.Sin(_waveNumberX * v.x + _waveNumberZ * v.z - _frequency * Time.time);
        }
        _meshFilter.mesh.SetVertices(_vertices);
    }
}
