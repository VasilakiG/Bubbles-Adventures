using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PauseMenuUI : MonoBehaviour
    {
        public void RestartGame()
        {
            GameManager.Instance.RestartGame();
        }

        public void MainMenu()
        {
            GameManager.Instance.MainMenu();
        }

        public void QuitGame()
        {
            GameManager.Instance.QuitGame();
        }
    }
}
