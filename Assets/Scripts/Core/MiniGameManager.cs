using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Core
{
    public class MiniGameManager : MonoBehaviour
    {
        public float MiniGameWaitTime = 60f; // Time to wait in mini game before starting next mini game
        private float _timer;
        private void Start()
        {
            _timer = MiniGameWaitTime;
        }
        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                SceneManager.LoadScene(1); // Load Lobby Scene
            }
        }
    }
}
