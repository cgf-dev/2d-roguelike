using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Variables
    public Transform playerTransform;
    public Vector3 offset;

    private void LateUpdate()
    {
        this.transform.position = playerTransform.position + offset;
    }
}
