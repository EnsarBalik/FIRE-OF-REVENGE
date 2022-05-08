using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolllow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offest;
    public Vector3 minValues, maxValues;
    void FixedUpdate()
    {
        Bounds();
    }
    void Bounds()
    {
        
        Vector3 targetPosition = target.position + offest;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValues.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z));
        
        Vector3 desiredPosition = target.position + offest;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, boundPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
