using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player movement speed
    public float speed = 10f;

    // Prefab of the bullet object to be instantiated
    public GameObject bulletPrefab;

    // Force to be applied to the bullet object
    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        // Get player input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the player in the calculated direction
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        // If the player is moving, shoot a bullet in the direction it's moving
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate a new bullet object
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Apply force to the bullet in the direction the player is moving
            Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(movementDirection * bulletForce, ForceMode.Impulse);
        }
    }
}