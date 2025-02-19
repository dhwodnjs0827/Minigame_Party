using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class OutOfRangeDetect : MonoBehaviour
    {
        private BoxCollider2D col;

        private void Awake()
        {
            col = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
}
