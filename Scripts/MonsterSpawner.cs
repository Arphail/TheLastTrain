using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _audioSource.Play();
    }
}
