using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelMonster : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _destinationPoint;
    [SerializeField] private float _speed;

    private void Update()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _destinationPoint.position, _speed * Time.deltaTime);
    }
}
