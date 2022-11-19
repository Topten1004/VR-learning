using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMaterial : MonoBehaviour
{
    private bool _isTurnedOn;
    public Material _materialOn;
    public Material _materialOff;
    private MeshRenderer _meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _isTurnedOn = true;
    }

    public void ToggleBulbMaterial()
    {
        if(!_isTurnedOn)
        {
            _meshRenderer.material = _materialOff;
        }
        else
        {
            _meshRenderer.material = _materialOn;
        }

        _isTurnedOn = !_isTurnedOn;
    }
}
