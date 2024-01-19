using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _m_Renderer;

    [SerializeField]
    private Material _offsetMaterial, _baseMaterial;

    [SerializeField]
    private Fruit _fruitPrefub;

    public void Init(bool isOffset, int fruitVariant)
    {
        _m_Renderer.material = isOffset ? _offsetMaterial : _baseMaterial;

        var fruit = Instantiate(_fruitPrefub, transform.position + new Vector3(0, 0.25f, 0), Quaternion.identity, transform);
        fruit.Init(fruitVariant);
    }
}
