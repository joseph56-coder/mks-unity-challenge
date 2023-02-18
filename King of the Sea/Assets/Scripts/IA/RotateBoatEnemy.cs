using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBoatEnemy : MonoBehaviour
{

    public float rotationSpeed = 3f;
    public void Rotate(Transform pointerPosition)
    {
        var offset = 90;
        Vector2 direction = pointerPosition.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
