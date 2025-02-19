using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        private PlayerController player;
        private ObjectPoolManager pool;

        private float elapsedTime;
        private Vector3 lastObstaclePos;
        private Vector3 lastEnviromentPos;

        private int score;

        public static GameManager Instance => instance;

        private void Awake()
        {
            instance = this;
            lastObstaclePos = new Vector3(4f, 0, 0);
            lastEnviromentPos = Vector3.zero;
            score = 0;
        }

        private void Start()
        {
            player = FindObjectOfType<PlayerController>();
            pool = ObjectPoolManager.Instance;

            ActiveEnviroment();
            ActiveObstacle();
        }

        private void Update()
        {
            if (player.IsDead)
            {
                return;
            }

            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 3f)
            {
                ActiveObstacle();
                ActiveEnviroment();
                elapsedTime = 0f;
            }
        }

        private void ActiveObstacle()
        {
            GameObject obstacle = pool.GetObstacle();
            obstacle.transform.position = lastObstaclePos + Vector3.right * Random.Range(5, 10);
            lastObstaclePos = obstacle.transform.position;
        }

        private void ActiveEnviroment()
        {
            GameObject enviroment = pool.GetEnviroment();
            enviroment.transform.position = lastEnviromentPos + Vector3.right * 22;
            lastEnviromentPos = enviroment.transform.position;
        }

        public void AddScore()
        {
            score++;
        }
    }
}
