using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private float speed = 5;
    private Vector3 angularVel;
    private Rigidbody rb;
    float born;
    float lifetime = 10;
    void Start()
    {
        born = Time.time;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        rb.velocity = (player.position - transform.position).normalized * speed + RandomVector3(3);

        float angularVel = Random.Range(1f, 6f);
        rb.rotation = Quaternion.Euler(RandomVector3(angularVel));
    }

    void FixedUpdate()
    {
        float force = 100;
        Vector3 diff = player.position - transform.position;
        float sqrDist = diff.sqrMagnitude;
        rb.AddForce((player.position - transform.position).normalized * force / sqrDist);

        if (lifetime < (Time.time - born))
        {
            Destroy(gameObject);
        }
    }

    public void OnClick() {
        Destroy(this.gameObject);
    }

    private Vector3 RandomVector3(float range) {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
