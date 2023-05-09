using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        rb.velocity = Vector3.forward;
    }
}