using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResetter : MonoBehaviour
{
    public RegisterGoals registerGoals;
    public SpawnBalls spawnBalls;

    void Update()
    {
        if (transform.localEulerAngles.z > 80 && transform.localEulerAngles.z < 150)
        {
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach(var bullet in bullets)
            {
                GameObject.Destroy(bullet);
            }
            registerGoals.ResetGoals();
            spawnBalls.Reset();
        }       
    }
}
