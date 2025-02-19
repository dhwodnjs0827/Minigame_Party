using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class ObjectPoolManager : MonoBehaviour
    {
        private static ObjectPoolManager instance;

        private GameObject obstaclePrefab;
        private GameObject enviromentPrefab;

        private List<GameObject> obstaclePoolList;
        private List<GameObject> enviromentPoolList;

        public static ObjectPoolManager Instance => instance;

        private void Awake()
        {
            instance = this;

            obstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacle");
            enviromentPrefab = Resources.Load<GameObject>("Prefabs/Enviroment");

            obstaclePoolList = new List<GameObject>();
            enviromentPoolList = new List<GameObject>();
        }

        private GameObject GetObstacleInPool()
        {
            GameObject findObject = obstaclePoolList.Find(o => o.gameObject.activeSelf == false && o.gameObject.name.Equals("Obstacle"));
            return findObject;
        }

        public GameObject GetObstacle()
        {
            GameObject obstacle = GetObstacleInPool();
            if (obstacle == null)
            {
                obstacle = Instantiate(obstaclePrefab);
                obstacle.transform.SetParent(gameObject.transform);
                obstaclePoolList.Add(obstacle);
            }
            else
            {
                obstacle.SetActive(true);
            }
            return obstacle;
        }

        private GameObject GetEnviromentInPool()
        {
            GameObject findObject = enviromentPoolList.Find(o => o.gameObject.activeSelf == false && o.gameObject.name.Equals("Enviroment"));
            return findObject;
        }

        public GameObject GetEnviroment()
        {
            GameObject obstacle = GetEnviromentInPool();
            if (obstacle == null)
            {
                obstacle = Instantiate(enviromentPrefab);
                obstacle.transform.SetParent(gameObject.transform);
                enviromentPoolList.Add(obstacle);
            }
            else
            {
                obstacle.SetActive(true);
            }
            return obstacle;
        }
    }
}
