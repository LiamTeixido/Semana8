using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1f);
=======
    protected Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        rb.velocity = Vector3.forward;
>>>>>>> 9b8ec2442179c04b25908d9e42bf3596ab5be646
    }
}
