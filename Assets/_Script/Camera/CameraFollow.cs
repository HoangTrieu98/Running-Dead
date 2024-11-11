using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;

    private void LateUpdate()
    {
        transform.position = cameraTarget.position;
        transform.rotation = cameraTarget.rotation;
    }
}
