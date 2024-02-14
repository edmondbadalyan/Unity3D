using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3 (25, 0, 0);
    public float time = 2;
    public float repeatRate = 2;
    private PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawnobstacle", time, repeatRate);
        controller =GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Spawnobstacle()
    {
        if (controller.GameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);

        }
        
        
    }

}
