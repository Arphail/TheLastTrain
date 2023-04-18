using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{
    [SerializeField] private Camera _jumpScareCamera;
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _screamerAudio;
    [SerializeField] private GameObject _endGameScreen;
    [SerializeField] private Monster _monster;

    private WaitForSeconds _jumpScareLength = new WaitForSeconds(1.5f);
    private Coroutine _jumpscare;

    public void OnTriggerEnter()
    {
        _monster.gameObject.SetActive(true);
        _screamerAudio.Play();
        _jumpScareCamera.gameObject.SetActive(true);
        _player.gameObject.SetActive(false);
        _jumpscare = StartCoroutine(JumpScareEndTimer());
    }

    private IEnumerator JumpScareEndTimer()
    {
        yield return _jumpScareLength;
        _endGameScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
