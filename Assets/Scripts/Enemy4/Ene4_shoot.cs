using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ene4_shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float shootingFrequency = 2f;
    public float playerDetectionRange = 5f;
    private float waitTimeForShot = 0f;
    private GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < playerDetectionRange)
        {
            if (Time.time > waitTimeForShot)
            {
                waitTimeForShot = Time.time + 1f / shootingFrequency;
                Shoot();
            }
        }
    }



    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rbBullet.velocity = direction * bulletSpeed;
        Destroy(bullet, 2f);
    }

}
