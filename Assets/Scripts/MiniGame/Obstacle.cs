using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class Obstacle : MonoBehaviour
    {
        private BoxCollider2D[] obstacles;

        private void OnEnable()
        {
            int removeIndex = Random.Range(1, obstacles.Length);
            int removeRange = Random.Range(2, 4);
            for (int i = removeIndex; i <= removeRange && i < obstacles.Length; i++)
            {
                obstacles[i].gameObject.SetActive(false);
            }
        }

        private void Awake()
        {
            obstacles = GetComponentsInChildren<BoxCollider2D>();
        }
    }
}
