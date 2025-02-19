using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aisle : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = GetComponent<PlayerController>();
            CameraController cam = GetComponent<CameraController>();
            cam.ChangeCameraPos(player.CurRoom.transform.position);
        }
    }
}
