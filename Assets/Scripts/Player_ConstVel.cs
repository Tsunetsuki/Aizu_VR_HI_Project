using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ConstVel : MonoBehaviour
{
    private GameObject cameraRig;
    public GameObject bullet;
    public float speed = 20f;
    public float bulletSpeed = 80;
    private void Start() {
        cameraRig = GameObject.FindGameObjectWithTag("Player");
    }


    void Update() {
        if (Input.GetMouseButton(0))
        {
            cameraRig.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
        else
        {
            //cameraRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (Input.GetMouseButtonDown(0) && bulletSpeed != 0)
        {
            GameObject newBullet = Instantiate(bullet, transform.position + transform.forward * 1, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        }

        
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 20);
    }

}
