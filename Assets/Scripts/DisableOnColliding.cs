using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnColliding : MonoBehaviour
{
    [SerializeField] string colliderTag = "Wall";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(colliderTag)) disable();
    }

    void disable()
    {
        Destroy(this.gameObject);
    }
}
