using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void ChangeCameraPos(Vector3 targetPos)
    {
        Vector3 endPos = targetPos;
        Vector3 target = new Vector3(endPos.x, endPos.y, transform.position.z);
        transform.position = target;
    }
}
