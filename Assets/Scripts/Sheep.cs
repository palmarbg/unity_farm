using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField]
    private Transform _sheepTarget;

    [SerializeField]
    private float _movementSpeed = 10.0f;

    [SerializeField]
    private float _rotationSpeed = 360.0f;

    [SerializeField]
    private float _minDistance = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Assert(_sheepTarget != null, "Sheep has no target set.");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toTarget = _sheepTarget.position - transform.parent.position;
        Vector2 toTarget2 = new(toTarget.x, toTarget.z);
        float distance = toTarget2.magnitude;
        toTarget2 = Vector2.Normalize(toTarget2);

        Vector2 currentLookDirection2 = new(transform.parent.forward.x, transform.parent.forward.z);
        currentLookDirection2 = Vector2.Normalize(currentLookDirection2);

        Vector3 toTargetDirection = new(toTarget2.x, 0, toTarget2.y);
        Vector3 currentLookDirection = new(currentLookDirection2.x, 0, currentLookDirection2.y);

        transform.parent.rotation = Quaternion.RotateTowards(
            Quaternion.LookRotation(currentLookDirection),
            Quaternion.LookRotation(toTargetDirection),
            _rotationSpeed * Time.deltaTime * .3f
            );

        if (Vector2.Dot(toTarget2, currentLookDirection2) > 0.7 && distance > _minDistance)
        {
            transform.parent.Translate(transform.parent.forward * Time.deltaTime * _movementSpeed, Space.World);
        }

    }
}
