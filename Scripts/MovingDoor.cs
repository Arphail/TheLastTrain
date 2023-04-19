using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource _openingSound;
    [SerializeField] private float _openSpeed;
    
    private Vector3 _openOffset = new Vector3(.8f, 0, 0);
    private Vector3 _targetPosition;
    private Coroutine _openCoroutine;
    private bool _closed = true;

    private void Start()
    {
        _targetPosition = transform.position + transform.TransformDirection(_openOffset);
    }

    public void OnInteract()
    {
        if (_closed)
        {
            _openCoroutine = StartCoroutine(OpenDoor());
            _openingSound.Play();
        }
    }

    private void OnDisable()
    {
        if (_openCoroutine != null)
            StopCoroutine(_openCoroutine);
    }

    public IEnumerator OpenDoor()
    {
        _closed = false;
        while (transform.position.x >= _targetPosition.x)
        {
            transform.position += new Vector3(_openSpeed * Time.deltaTime, 0, 0);
            yield return null;
        }
    }
}
 
