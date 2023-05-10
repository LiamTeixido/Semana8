using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ene4_bullet : Bullet
{

    public GameObject player;
    public float moveSpeed;
    public float followTime;

    private float followTimer;
    private bool returning;

    private Vector3 originalPosition;
    private Vector3 originalDirection;

    void Start()
    {
        originalPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

        followTimer = followTime;
    }

    protected override void Update()
    {
        if (!returning)
        {
            if (followTimer > 0)
            {
                originalDirection = rb.velocity = (player.transform.position - transform.position).normalized;
                rb.velocity = (originalDirection * moveSpeed);
                followTimer -= Time.deltaTime;
            }
            else
            {
                returning = true;
            }
        }
    }
}
