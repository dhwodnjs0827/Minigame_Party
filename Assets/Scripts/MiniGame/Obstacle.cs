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
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].gameObject.SetActive(true);
            }

            int removeIndex = Random.Range(1, obstacles.Length - 1);
            removeIndex = Mathf.Clamp(removeIndex, 1, obstacles.Length - 1);
            int removeRange = Random.Range(3, 4);
            for (int i = removeIndex; i < removeIndex + removeRange && i < obstacles.Length; i++)
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
