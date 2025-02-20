using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum UIState
{
    Start,
    Game,
    GameOver
}

namespace MiniGame
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager instance;

        private UIState curUIState;

        [SerializeField] private StartUI startUI;
        [SerializeField] private GameUI gameUI;
        [SerializeField] private GameOverUI gameOverUI;

        private GameManager gameManager;

        public static UIManager Instance => instance;

        private void Awake()
        {
            instance = this;

            startUI = GetComponentInChildren<StartUI>(true);
            startUI.Initialize(this);
            gameUI = GetComponentInChildren<GameUI>(true);
            gameUI.Initialize(this);
            gameOverUI = GetComponentInChildren<GameOverUI>(true);
            gameOverUI.Initialize(this);

            ChangeUIState(UIState.Start);
        }

        private void Start()
        {
            gameManager = GameManager.Instance;
        }

        public void StartGame()
        {
            gameUI.SetBestScore();
            ChangeUIState(UIState.Game);
        }

        public void GameOver()
        {
            gameUI.SetBestScore();
            ChangeUIState(UIState.GameOver);
        }

        private void ChangeUIState(UIState state)
        {
            curUIState = state;
            startUI.SetActive(curUIState);
            gameUI.SetActive(curUIState);
            gameOverUI.SetActive(curUIState);
        }
    }
}
