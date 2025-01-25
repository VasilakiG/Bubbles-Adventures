using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        private float _scoreAmount;

        // Start is called before the first frame update
        private void Start()
        {
            ResetScore();
        }

        public void AddToScore()
        {
            _scoreAmount += Time.deltaTime;
            _scoreText.text = Mathf.RoundToInt(_scoreAmount).ToString();
        }

        public void ResetScore()
        {
            _scoreAmount = 0;
            _scoreText.text = _scoreAmount.ToString();
        }
    }
}
