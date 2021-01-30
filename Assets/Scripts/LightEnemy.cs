﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : MonoBehaviour
{
    int layerMask = ~(1 << 8);
    public float range;
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, layerMask);

        // If it hits something...
        if (hit.collider.tag != null)
        {
            if(hit.collider.tag == "Antipolilla")
            {
                hit.collider.GetComponent<Antipolilla>().iluminado = true;
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * range, Color.white);
        }
    }
}