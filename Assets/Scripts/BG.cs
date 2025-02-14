using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private MeshRenderer meshRenderer;

    private Vector2 _meshOffset;

    private void Start()
    {
        _meshOffset = meshRenderer.sharedMaterial.mainTextureOffset;
    }

    private void OnDisable()
    {
        meshRenderer.sharedMaterial.mainTextureOffset = _meshOffset;
    }

    private void Update()
    {
        var x = Mathf.Repeat(Time.time * speed, 1);

        var offset = new Vector2(x, _meshOffset.y);

        meshRenderer.sharedMaterial.mainTextureOffset = offset;
    }
}
