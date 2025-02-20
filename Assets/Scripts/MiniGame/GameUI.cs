using MiniGame;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MiniGame
{
    public class GameUI : BaseUI
    {
        [SerializeField] private TextMeshProUGUI bestScoreTxt;
        [SerializeField] private TextMeshProUGUI curScoreTxt;

        public override void Initialize(UIManager uiManager)
        {
            base.Initialize(uiManager);
        }

        private void Update()
        {
            curScoreTxt.text = $"Score: {GameManager.Instance.Score}";
        }

        public void SetBestScore()
        {
            bestScoreTxt.text = $"BestScore: {GameManager.Instance.BestScore}";
        }

        protected override UIState GetUIState()
        {
            return UIState.Game;
        }
    }
}
