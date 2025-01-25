using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _optionsMenu;

        public void Play()
        {
            SceneManager.LoadScene(1);
        }

        public void ActivateMainMenu(bool state)
        {
            _mainMenu.SetActive(state);
            _optionsMenu.SetActive(!state);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void Start()
        {
            ActivateMainMenu(true);
        }
    }
}
