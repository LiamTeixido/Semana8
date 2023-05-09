using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public GameObject puntoA;
    public GameObject puntoB;
    public float velocity = 1.0f;
    private float Reloud = 0.0f;
    public GameObject Bullet;
    public float ForceBullet;
    public GameObject spawnPoint;
    private  float timer;
    public float timeBetweenShots;

    public void Start()
    {

        timer = timeBetweenShots;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        Movement();

        DispararProyectil();
    }



    public void Movement()
    {
        Reloud += velocity * Time.deltaTime;
        transform.position = Vector3.Lerp(puntoA.transform.position, puntoB.transform.position, Reloud);

        if (Reloud > 1.0f)
        {
            float temp = puntoB.transform.position.x;
            puntoB.transform.position = puntoA.transform.position;
            puntoA.transform.position = new Vector3(temp, puntoA.transform.position.y, puntoA.transform.position.z);
            Reloud = 0.0f;
        }


        Vector3 direccionMovimiento = (puntoB.transform.position - puntoA.transform.position).normalized;


        transform.LookAt(transform.position + direccionMovimiento);
    }
    void DispararProyectil()
    {
        if (timer <= 0)
        {
            timer = timeBetweenShots;

            Vector3 shootDirection = ForceBullet > 0 ? Vector3.right : Vector3.left;

            GameObject newBullet = Instantiate(Bullet, spawnPoint.transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = shootDirection * 30;
        }
    }




}





