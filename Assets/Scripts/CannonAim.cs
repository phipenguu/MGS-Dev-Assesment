using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAim : MonoBehaviour
{
    public float cannonRotationSpeed = 5.0f;

    [SerializeField] private float angle;

    public void Aim(Vector2 pointerPosition)
    {
        var cannonDirection = (Vector3)pointerPosition - transform.position;
        cannonDirection.z = 0;
        angle = Mathf.Atan2(cannonDirection.y, cannonDirection.x) * Mathf.Rad2Deg - 90.0f;
        angle = Mathf.Clamp(angle, -75, 75);
        float cannonRotate = cannonRotationSpeed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), cannonRotate);
    }
}