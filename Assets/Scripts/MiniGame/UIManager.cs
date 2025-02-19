using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MiniGame
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI bestScoreTxt;
        [SerializeField] private TextMeshProUGUI curScoreTxt;
        [SerializeField] private GameObject gameOverImagae;

        private GameManager gameManager;

        private void Start()
        {
            gameManager = GameManager.Instance;
        }

        private void Update()
        {
            if (gameManager.IsGameOver)
            {
                gameOverImagae.SetActive(true);
                return;
            }
            curScoreTxt.text = $"Score: {gameManager.Score}";
        }
    }
}
