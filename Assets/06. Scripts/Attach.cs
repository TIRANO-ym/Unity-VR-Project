using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{
    [SerializeField]
    Transform cameraTransform;
    [SerializeField]
    Vector3 offsetFromCamera;
    [SerializeField]
    float turnBufferInDegrees = 0f;
    [SerializeField]
    float turnSpeed = 0.18f;

    void Update()
    {
        transform.position = cameraTransform.position + offsetFromCamera;

        Vector3 cameraEuler = cameraTransform.rotation.eulerAngles;

        Quaternion targetQuat = Quaternion.Euler(cameraEuler);

        float angle = Quaternion.Angle(transform.rotation, targetQuat);

        if (angle > turnBufferInDegrees)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetQuat, turnSpeed);
        }
    }
}
