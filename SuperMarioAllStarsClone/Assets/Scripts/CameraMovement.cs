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
    [SerializeField] private Transform target;

    [Header("Variable Readings")]
    [SerializeField] private Vector3 CameraStartBounds = new Vector3(-4.168548f, -0.6146467f, -10f);
    [SerializeField] private Vector3 CameraEndBounds = new Vector3(153.800003f, -0.614646673f, -10f);
    [SerializeField] private Vector3 CameraPos;
    public float testTargetPosX;

    private void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Vector3.zero;
        CameraPos = transform.position;

        targetPosition.x = target.position.x + offset.x;
        targetPosition.y = bottomCameraLock;
        targetPosition.z = targetPosition.z + offset.z;
        
        testTargetPosX = targetPosition.x;

        if (targetPosition.x >= -10)
        {
            if (CameraPos.x <= CameraStartBounds.x && targetPosition.x <= CameraStartBounds.x)
            {
                targetPosition.x = CameraStartBounds.x;
                transform.position = targetPosition;
            }

            if (CameraPos.x >= CameraEndBounds.x && targetPosition.x >= CameraEndBounds.x)
            {
                targetPosition.x = CameraEndBounds.x;
                transform.position = targetPosition;
            }

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
