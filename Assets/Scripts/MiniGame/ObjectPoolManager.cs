using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class ObjectPoolManager : MonoBehaviour
    {
        private static ObjectPoolManager instance;

        private GameObject obstaclePrefab;

        private List<GameObject> obstaclePoolList;

        public static ObjectPoolManager Instance => instance;

        private void Awake()
        {
            instance = this;

            obstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacle");

            obstaclePoolList = new List<GameObject>();
        }

        private GameObject GetDisableObjectInPool()
        {
            GameObject findObject = obstaclePoolList.Find(o => o.gameObject.activeSelf == false);
            return findObject;
        }

        public GameObject GetObstacle()
        {
            GameObject obstacle = GetDisableObjectInPool();
            if (obstacle == null)
            {
                obstacle = Instantiate(obstaclePrefab);
                obstaclePoolList.Add(obstacle);
            }
            else
            {
                obstacle.SetActive(true);
            }
            return obstacle;
        }
    }
}
