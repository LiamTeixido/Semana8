using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3_Movement : MonoBehaviour, IDamage
{
    Rigidbody rb;
    public Transform target;
    public float moveDistance = 5.0f;
    public float moveSpeed = 10.0f;

    private Vector3 moveDirection;

    float damage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        moveDirection = (transform.position - target.position).normalized;
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget < moveDistance)
        {
            moveDirection = (transform.position - target.position).normalized;
            Vector3 force = moveDirection * moveSpeed * 1.2f;

            rb.AddForce(force);
        }
    }

    public float GetDamage()
    {
        return damage;
    }
}
