using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 0.5f)]
    private float _minIntensity = 0.0f;

    [SerializeField]
    [Range(0.5f, 1.0f)]
    private float _maxIntensity = 1.0f;

    [SerializeField]
    private float _blinkingSpeed = 2.0f;

    private Light _light;
    private float _startIntensity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _light = GetComponent<Light>();
        _startIntensity = _light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        var intensity = Mathf.PerlinNoise(_blinkingSpeed * Time.time, 4.6f);
        intensity = Mathf.Clamp(intensity, _minIntensity, _maxIntensity);
        _light.intensity = intensity * _startIntensity;
    }
}
