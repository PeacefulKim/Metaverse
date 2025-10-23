using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Transform leftWall;
    public Transform rightWall;
    public float minX;
    public float maxX;

    void Start()
    {
        if (target == null) return; 
        float cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        minX = leftWall.position.x + cameraHalfWidth;
        maxX = rightWall.position.x - cameraHalfWidth;

        if (maxX < minX)
        {
            float center = (leftWall.position.x + rightWall.position.x) / 2f;
            minX = maxX = center;
        }
    }
    void LateUpdate()
    {
        if (target == null) return;

        float targetX = Mathf.Clamp(target.position.x, minX, maxX);
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
