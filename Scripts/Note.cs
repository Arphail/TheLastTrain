using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    [SerializeField] private Canvas _canvas;

    public void OnFocus()
    {
        _canvas.gameObject.SetActive(true);
        print("Reading");
    }

    public void OnLoseFocus()
    {
        _canvas.gameObject.SetActive(false);
        print("Not reading");
    }
}
