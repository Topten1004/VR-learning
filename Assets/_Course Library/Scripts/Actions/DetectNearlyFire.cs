using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectNearlyFire : MonoBehaviour
{
    private ToggleParticle _particles;

    // Start is called before the first frame update
    void Start()
    {
        _particles = GetComponentInChildren<ToggleParticle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_particles != null )
        {
            if (other.CompareTag("Fire"))
            {
                _particles.Play();
            }
        }
    }
}
