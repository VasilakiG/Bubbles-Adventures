using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public bool IsPaused { get; private set; } = false;
        public bool IsGameOver { get; private set; } = false;

        [SerializeField] private GameObject _hudCanvas;
        [SerializeField] private GameObject _pauseCanvas;
        [SerializeField] private GameObject _gameEndingCanvas;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            SetActiveHUD(true);
            SetActivePause(false);
            SetActiveGameEnding(false);
        }

        private void Update()
        {
            if (!IsGameOver)
            {
                switch (IsPaused)
                {
                    case false when (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)):
                        SetActivePause(true);
                        break;
                    case true when (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)):
                        SetActivePause(false);
                        break;
                }
            }
        }

        public void EndGame()
        {
            IsGameOver = true;
            IsPaused = false;
            SetActiveGameEnding(true);
            SetActiveHUD(false);
        }

        public void RestartGame()
        {
            IsPaused = false;
            IsGameOver = false;
            SceneManager.LoadScene(1);
        }

        public void MainMenu()
        {
            IsPaused = false;
            IsGameOver = false;
            SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void SetActiveHUD(bool state)
        {
            _hudCanvas.SetActive(state);
            _gameEndingCanvas.SetActive(!state);

            if (!IsGameOver)
            {
                _pauseCanvas.SetActive(!state);
            }
        }

        private void SetActivePause(bool state)
        {
            _pauseCanvas.SetActive(state);
            _hudCanvas.SetActive(!state);

            Time.timeScale = state ? 0 : 1;
            IsPaused = state;
        }

        private void SetActiveGameEnding(bool state)
        {
            if (_gameEndingCanvas != null)
            {
                _gameEndingCanvas.SetActive(state);
            }
            else
            {
                Debug.LogWarning("Game Ending Canvas is missing!");
            }
        }
    }
}
