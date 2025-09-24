using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;
    private Vector3 cameraVelocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothSpeed);
    }
}
