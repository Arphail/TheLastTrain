using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private FirstPersonController _firstPersonController;

    public void Die()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
        _deathScreen.SetActive(true);
        _firstPersonController.cameraCanMove = false;
    }
}
