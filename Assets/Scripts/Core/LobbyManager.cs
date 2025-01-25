using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Core
{
    public class LobbyManager : MonoBehaviour
    {
        public float LobbyWaitTime = 30f; // Time to wait in lobby before starting game
        private float _timer;

        private void Start()
        {
            _timer = LobbyWaitTime;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
            {
                LoadRandomMiniGame();
            }
        }

        private void LoadRandomMiniGame()
        {
            int randomMiniGame = Random.Range(2, 4);
            SceneManager.LoadScene(randomMiniGame);
        }
    }
}
