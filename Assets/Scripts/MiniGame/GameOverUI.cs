using MiniGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MiniGame
{
    public class GameOverUI : BaseUI
    {
        [SerializeField] private Button restartBtn;
        [SerializeField] private Button exitBtn;

        public override void Initialize(UIManager uiManager)
        {
            base.Initialize(uiManager);
            restartBtn.onClick.AddListener(OnClickRestartButton);
            exitBtn.onClick.AddListener(OnClickExitButton);
        }

        private void OnClickRestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.Instance.StartGame();
        }

        private void OnClickExitButton()
        {
            GameManager.Instance.ExitGame();
        }

        protected override UIState GetUIState()
        {
            return UIState.GameOver;
        }
    }
}
