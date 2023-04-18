using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSoundMaker : MonoBehaviour
{
    [SerializeField] private AudioSource _stepSound;
    [SerializeField] private FirstPersonController _firstPersonController;

    private void Start()
    {
        _firstPersonController.HeadBobed.AddListener(OnBob);
    }

    private void OnBob()
    {
        _stepSound.Play();
    }
}
