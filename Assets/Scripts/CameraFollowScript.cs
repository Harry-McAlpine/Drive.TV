using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform Target;
    public float SwayOffset;
    public float SwaySpeed;

    void Update()
    {
        Transform cameraTransform = GetComponent<Transform>();
        //cameraTransform.SetPositionAndRotation(cameraTransform.position, new Quaternion(cameraTransform.rotation.x, 0, 0, cameraTransform.rotation.w));

        float angle = Input.GetAxis("Horizontal");

        float speed = (-(4f * Mathf.Abs(cameraTransform.localPosition.x / SwayOffset)) + 1f) * SwaySpeed * Time.deltaTime;

        if (angle > 0 && cameraTransform.localPosition.x <= SwayOffset)
        {
            if (cameraTransform.localPosition.x < 0)
            {
                cameraTransform.Translate(SwaySpeed * Time.deltaTime, 0f, 0f, Space.Self);
            }
            else
            {
                cameraTransform.Translate(speed, 0f, 0f, Space.Self);
            }
        }
        else if (angle < 0 && cameraTransform.localPosition.x >= -SwayOffset)
        {
            if (cameraTransform.localPosition.x > 0)
            {
                cameraTransform.Translate(-SwaySpeed * Time.deltaTime, 0f, 0f, Space.Self);
            }
            else
            {
                cameraTransform.Translate(-speed, 0f, 0f, Space.Self);
            }
        }
    }
}
