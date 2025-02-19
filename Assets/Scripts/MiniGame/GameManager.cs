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

        private Vector3 lastObstacelPos;

        public Vector3 LastObstaclePos => lastObstacelPos;

        public static GameManager Instance => instance;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            player = FindObjectOfType<PlayerController>();
            pool = ObjectPoolManager.Instance;

            lastObstacelPos = new Vector3(4f, 0, 0);
        }

        private void Update()
        {
            ActiveObstacle();
        }

        private void ActiveObstacle()
        {
            GameObject obstacle = pool.GetObstacle();
            obstacle.transform.position = lastObstacelPos + Vector3.right * Random.Range(3f, 5f);
        }
    }
}
