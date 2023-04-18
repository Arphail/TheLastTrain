using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerZombie : MonoBehaviour
{
    [SerializeField] private Transform _zombieFinalPosition;
    [SerializeField] private float _approachSpeed;
    [SerializeField] private Light _light;

    private Vector3 _targetPosition;
    private Coroutine _jumpScareMovement;
    private WaitForSeconds _hangingLength = new WaitForSeconds(1f);

    private void OnEnable()
    {
        _jumpScareMovement = StartCoroutine(JumpScareMovement());
    }

    private IEnumerator JumpScareMovement()
    {
        yield return _hangingLength;
        _light.gameObject.SetActive(true);

        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _zombieFinalPosition.position, _approachSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
