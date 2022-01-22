using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        private GameObject _pauseMenu;
        private bool _isPausing;

        private InputSystem _inputSystem;
        
        private void OnEnable()
        {
            _inputSystem.JumpGame.Enable();
        }

        private void OnDisable()
        {
            _inputSystem.JumpGame.Disable();
        }
        
        private void Awake()
        {
            _inputSystem = new InputSystem();
            _inputSystem.JumpGame.Pause.started += ctx => PauseAndResume();
            
            _pauseMenu = transform.GetChild(0).gameObject;
        }

        private void Start()
        {
            _pauseMenu.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { PauseAndResume(); });
            _pauseMenu.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate { BackToMainMenu(); });
            _pauseMenu.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { QuitGame(); });
        }

        private void PauseAndResume()
        {
            if (_isPausing)
            {
                _pauseMenu.SetActive(false);
                Time.timeScale = 1;
                _isPausing = false;
                return;
            }
            Time.timeScale = 0;
            _pauseMenu.SetActive(true);
            _isPausing = true;
        }

        private void BackToMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
