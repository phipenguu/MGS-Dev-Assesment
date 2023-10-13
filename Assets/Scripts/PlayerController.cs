using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CannonAim cannonAim;
    public CannonBehavior cannonBehavior;
    void Awake()
    {
        if (cannonAim == null)
        {
            cannonAim = GetComponentInChildren<CannonAim>();
        }

        if (cannonBehavior == null)
        {
            cannonBehavior = GetComponentInChildren<CannonBehavior>();
        }
    }

    public void HandleShoot()
    {
        cannonBehavior.Shoot();
    }

    public void HandleMoveCannon(Vector2 pointerPosition)
    {
        cannonAim.Aim(pointerPosition);
    }
}