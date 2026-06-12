using UnityEngine;

public class UVScroller : MonoBehaviour
{
    [SerializeField]
    private Vector2 _uvSpeed = new Vector2(0.5f, 0.1f);

    private Vector2 _uvOffset = new Vector2(0, 0);
    private MeshRenderer _meshRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _uvOffset += _uvSpeed * Time.deltaTime;
        _meshRenderer.material.SetTextureOffset("_BaseMap", _uvOffset);
    }
}
