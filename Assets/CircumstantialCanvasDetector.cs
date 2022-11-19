using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;

public class CircumstantialCanvasDetector : MonoBehaviour
{
    public float _radius = 1.5f;
    public float _maxDistance = 1.5f;
    public LayerMask _layer;
    [Serializable] public class CollisionEvent : UnityEvent<Collision> { }

    // When the object enters a collision
    public UnityEvent OnEnter = new UnityEvent();

    // When the object exits a collision
    public UnityEvent OnExit = new UnityEvent();

    private RaycastHit[] _raycastHitResults;
    private int _countRayHitResults;
    private bool _wasInside = false;

    // Start is called before the first frame update
    void Start()
    {
        _raycastHitResults = new RaycastHit[200];
        StartCoroutine(SearchCollisions());
    }
 
    IEnumerator SearchCollisions()
    {
        while (true)
        {
            _countRayHitResults = Physics.SphereCastNonAlloc(transform.position, _radius, transform.forward, _raycastHitResults, _maxDistance, _layer, QueryTriggerInteraction.UseGlobal);
            
            if (Search())
            {
                if (!_wasInside)
                {
                    _wasInside = true;
                    OnEnter.Invoke();
                }
            }
            else
            {
                if (_wasInside)
                {
                    _wasInside = false;
                    OnExit.Invoke();
                }
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private bool Search()
    {
        var isInside = false;

        for (int i = 0; i < _countRayHitResults; i++)
        {
            if (_raycastHitResults != null)
            {
                if (_raycastHitResults[i].transform.CompareTag("Player"))
                {
                    isInside = true;
                    i = _raycastHitResults.Length;
                }
            }
        }
        return isInside;
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
