using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PlayerTeleporter : MonoBehaviour
{
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = gameObject.transform;
    }

    public void Teleport(Transform destinationPoint)
    {
        _playerTransform.position = destinationPoint.position;
    }
}
