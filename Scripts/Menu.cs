using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;
    [SerializeField] FirstPersonController _playerController;
    

    private void Start()
    {
        _playerController.cameraCanMove = false;
        _playerController.playerCanMove = false;
        Cursor.lockState = CursorLockMode.Confined;
        _mainMenu.SetActive(true);
    }

    public void OnGameStarted()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerController.cameraCanMove = true;
        _playerController.playerCanMove = true;
        _mainMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
