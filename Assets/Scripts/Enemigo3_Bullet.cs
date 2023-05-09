using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3_Bullet : Bullet
{

    public GameObject player;
    public float moveSpeed = 10.0f;
    public float followTime = 1.0f;
    public float returnSpeed = 5.0f;

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
                //rb.MovePosition(rb.position + originalDirection * moveSpeed * Time.fixedDeltaTime);
                originalDirection = (player.transform.position - transform.position).normalized;
                rb.velocity = (originalDirection * moveSpeed);
                followTimer -= Time.deltaTime;
            }
            else
            {
                returning = true;
            }
        }
        else
        {
            Vector3 returnDirection = (originalPosition - transform.position).normalized;
            //rb.MovePosition(rb.position + returnDirection * returnSpeed * Time.fixedDeltaTime);
            rb.velocity = (returnDirection * returnSpeed);

            if(Vector3.Distance(originalPosition, transform.position) <= 0.3f)
            {
                Destroy(gameObject);
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.GetComponent<Enemigo3_Shooting>() != null)
    //    {
    //        if(returning)
    //            Destroy(gameObject);
    //    }
    //}
}
