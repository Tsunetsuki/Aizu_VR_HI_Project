using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{

    public Transform target;
    public GameObject bullet;
    public float moveSpeed = 10;
    private Rigidbody rb;
    public float averageVh;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 120 == 0) Shoot();
    }

    private void FixedUpdate() {
        if (Input.GetKey("s")) rb.AddForce(-transform.up * moveSpeed);
        if (Input.GetKey("w")) rb.AddForce(transform.up * moveSpeed);
        if (Input.GetKey("a")) rb.AddForce(-transform.right * moveSpeed);
        if (Input.GetKey("d")) rb.AddForce(transform.right * moveSpeed);
        if (Input.GetKey("q")) rb.AddForce(-transform.forward * moveSpeed);
        if (Input.GetKey("e")) rb.AddForce(transform.forward * moveSpeed);
    }

    private void Shoot() {
        float vh = Random.Range(averageVh * 0.5f, averageVh * 1.5f);
        float x = target.transform.position.x - transform.position.x;
        float y = target.transform.position.y - transform.position.y;
        float z = target.transform.position.z - transform.position.z;
        float dh = Mathf.Sqrt(x * x + z * z);
        Vector3 towardTarget = new Vector3(x, 0, z).normalized;
        float g = -Physics.gravity.y;

        float t = dh / vh;
        float vy = (y/t) + 0.5f*g*t;

        Vector3 velocity = vh * towardTarget + vy * transform.up;

        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = velocity;
    }
}
