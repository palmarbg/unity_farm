using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _cameraTarget;

    [SerializeField]
    private float _cameraHeight = 5.0f;

    [SerializeField]
    private float _cameraDistance = 10.0f;

    [SerializeField]
    private float _cameraAngle = -15.0f;

    [SerializeField]
    private float _cameraSmoothing = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Assert(_cameraTarget != null, "Camera has no target set.");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        Vector3 pos = new(_cameraTarget.position.x, _cameraHeight, _cameraTarget.position.z);
        Vector3 direction = _cameraTarget.transform.TransformVector(Vector3.back);
        transform.position = Vector3.MoveTowards(transform.position, pos + _cameraDistance * direction, Time.deltaTime / _cameraSmoothing);

        transform.rotation = Quaternion.LookRotation(_cameraTarget.position - transform.position);
    }
}
