using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMover : MonoBehaviour
{
    [SerializeField] private Transform _monsterTransform;
    [SerializeField] private float _speed;

    private bool _canMove;

    private void OnEnable()
    {
        _canMove = true;
    }

    private void Update()
    {
        if( _canMove)
            _monsterTransform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
