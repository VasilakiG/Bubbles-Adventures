using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Animator _playerAnimator;
        private bool _isFirstTime = true;

        public bool IsSpacePressed { get; private set; }
        public ScoreManager ScoreManager;

        private void Start()
        {
            _playerAnimator = GetComponent<Animator>();

            if (_playerAnimator == null)
            {
                Debug.LogError("Animator component not found on the player.");
            }
        }

        private void Update()
        {
            if (/*!_playerEnergyBar.IsCoolingDown ||*/ _isFirstTime)
            {
                ScoreManager.AddToScore();
                //CoolingDownText.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    IsSpacePressed = true;
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    IsSpacePressed = false;
                }
                _isFirstTime = false;
            }
            else
            {
                IsSpacePressed = false;
                //CoolingDownText.SetActive(true);
            }

            // Update the boolean parameter in the Animator
            _playerAnimator.SetBool("ClickedSpace", IsSpacePressed);
        }
    }
}
