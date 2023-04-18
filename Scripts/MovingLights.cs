using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLights : MonoBehaviour
{
    [SerializeField] private Light[] _lights;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private Transform _destinationPoint;
    [SerializeField] private Transform _startingPosition;

    private Coroutine _moveLight;

    private void Start()
    {
    }

    private void Update()
    {
        foreach(var light in _lights)
        {
            _moveLight = StartCoroutine(MoveLight(light));

            if (light.transform.position == _destinationPoint.position)
                light.transform.position = _startingPosition.position;
        }
    }

    private IEnumerator MoveLight(Light light)
    {
        while(light.transform.position != _destinationPoint.position)
        {
            light.transform.position = Vector3.MoveTowards(light.transform.position, _destinationPoint.position, _movingSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
