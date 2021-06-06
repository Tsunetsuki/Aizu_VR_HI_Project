using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletReaction : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource ksh;
    public AudioSource doryaa;
    private Transform goal;

    private void Start() {
        goal = GameObject.FindGameObjectWithTag("Goal").transform;
    }
    public void WhenHit() {
        Vector3 deflectDir = (transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized;
        rb.AddForce(deflectDir * Random.Range(30000, 100000));
        
        if ((goal.position - transform.position).magnitude < 20)
        {
            //doryaa.pitch = Random.Range(0.3f, 1.5f);
            doryaa.Play();
        }
        else
        {
            ksh.Play();
        }
    }
}
