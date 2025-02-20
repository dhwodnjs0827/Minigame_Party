using MiniGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGame
{
    public class StartUI : BaseUI
    {
        [SerializeField] private Button startBtn;
        [SerializeField] private Button exitBtn;

        public override void Initialize(UIManager uiManager)
        {
            base.Initialize(uiManager);
            startBtn.onClick.AddListener(OnClickStartButton);
            exitBtn.onClick.AddListener(OnClickExitButton);
        }

        private void OnClickStartButton()
        {
            GameManager.Instance.StartGame();
        }

        private void OnClickExitButton()
        {
            GameManager.Instance.ExitGame();
        }

        protected override UIState GetUIState()
        {
            return UIState.Start;
        }
    }
}
