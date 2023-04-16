using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private const float bottomCameraLock = -0.6146467f;
    private const float topCameraLock = 13.25f;
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 CameraStartBounds = new Vector3(-4.16854f, -0.6146467f, - 10f);
    
    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Vector3.zero;


        targetPosition.x = target.position.x + offset.x;
        targetPosition.y = bottomCameraLock;
        targetPosition.z = targetPosition.z + offset.z;

        if (targetPosition.x >= CameraStartBounds.x)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        
    }
}
