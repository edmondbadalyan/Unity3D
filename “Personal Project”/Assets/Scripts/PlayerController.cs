using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float xboundary = 9;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();


    }


    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Horizontal");
        float horizontalInput = Input.GetAxis("Vertical");

        rb.AddForce(Vector3.forward * speed * verticalInput);
        rb.AddForce(Vector3.right * speed * horizontalInput);
    }

    void ConstrainPlayerPosition()
    {
           if (transform.position.x > xboundary)
           {
            transform.position = new Vector3(9, transform.position.y, transform.position.z);
           }
           if (transform.position.x < -4)
           {
            transform.position = new Vector3(-4, transform.position.y, transform.position.z);
           }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with the enemy");
        }   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
