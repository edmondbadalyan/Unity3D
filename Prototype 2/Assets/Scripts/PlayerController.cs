using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playermove;
    public float playermovespeed = 20.0f;
    public float xRange = 25.0f;
    public GameObject pizzathrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        playermove = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * playermovespeed * playermove );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(pizzathrow,transform.position,pizzathrow.transform.rotation);
        }




        
    }
}
