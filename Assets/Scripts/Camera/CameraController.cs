using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void ChangeCameraPos(Vector2 targetPos)
    {
        float targetY = targetPos.y;
        Vector3 target = new Vector3(transform.position.x, targetY, transform.position.z);
        transform.position = target;
    }
}
