using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool isPowerUp = false;
    public float powerUpStrength = 15.0f;
    public GameObject PowerUpActive;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        rigidbody.AddForce(focalPoint.transform.forward * verticalInput * speed);

        PowerUpActive.transform.position = transform.position + new Vector3(0,-0.5f,0);
    }


    IEnumerator PowerupCountdownRoutine() {

        yield return new WaitForSeconds(powerUpStrength);
        isPowerUp = false;
        PowerUpActive.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("PowerUp"))
        {
            isPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            PowerUpActive.gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);

            Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + isPowerUp);
        }
    }
}
