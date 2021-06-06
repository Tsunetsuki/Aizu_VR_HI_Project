using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Random.Range(0, 60) == 0)
        {

            Instantiate(enemy);
        }
    }
}
