using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorBlock : MonoBehaviour, IInteractable
{
    [SerializeField] private Canvas _canvas;

    private WaitForSeconds _messageTimer = new WaitForSeconds(2);
    private Coroutine _timerCoroutine;

    public void OnInteract()
    {
        _timerCoroutine = StartCoroutine(MessageTimer());
    }

    public IEnumerator MessageTimer()
    {
        _canvas.gameObject.SetActive(true);
        yield return _messageTimer;
        _canvas.gameObject.SetActive(false);
    }
}
