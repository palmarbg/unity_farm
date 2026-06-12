using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SeasonManager : MonoBehaviour
{
    [SerializeField]
    private List<MeshRenderer> _meshRendererList;

    [SerializeField]
    private Material _grassMaterial;

    [SerializeField]
    private Material _snowMaterial;

    private enum Season
    {
        Summer, Winter
    }

    [SerializeField]
    private Season _season;

    private bool playerInside;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside && Keyboard.current.eKey.wasPressedThisFrame)
        {
            ToggleSeason();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }

    private void ToggleSeason()
    {
        _season = _season switch
        {
            Season.Summer => Season.Winter,
            Season.Winter => Season.Summer,
            _ => throw new System.NotImplementedException()
        };

        Material mat = _season switch
        {
            Season.Summer => _grassMaterial,
            Season.Winter => _snowMaterial,
            _ => throw new System.NotImplementedException()
        };

        foreach (var meshRenderer in _meshRendererList)
        {
            meshRenderer.material = mat;
        }
    }
}
