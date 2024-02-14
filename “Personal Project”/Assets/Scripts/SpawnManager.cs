using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject powerUp;
    private float zrandomRange = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRange", 1, 2);
        InvokeRepeating("PowerUpSpawn",1,2);
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }



    void SpawnRange()
    {
        int randomIndex = Random.Range(0, enemy.Length);
        float randomPos = Random.Range(zrandomRange, -zrandomRange);

        Vector3 spawn = new Vector3 (15,1.35f,randomPos);
        Instantiate(enemy[randomIndex], spawn, enemy[randomIndex].transform.rotation);

    }

     void PowerUpSpawn()
     {

        float randomPosZ = Random.Range(zrandomRange, -zrandomRange);
        float randomPosX = Random.Range(-4,10);

        Vector3 spawn = new Vector3(randomPosX,0.75f,randomPosZ);
        Instantiate(powerUp,spawn,powerUp.transform.rotation);
     }

}
