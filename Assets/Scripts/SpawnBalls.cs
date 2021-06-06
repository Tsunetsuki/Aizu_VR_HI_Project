using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    public Transform target;
    public GameObject bullet;
    private Rigidbody rb;
    public float averageVh;

    public float zRange;
    public float yRange;

    public float shootEveryInitial;
    public float shootEveryHalfLife;
    private float shootEvery;
    private float lastReset;

    private void OnDrawGizmos() {
        Vector3 pos = transform.position;
        Gizmos.DrawLine(pos + new Vector3(0, -yRange, -zRange), pos + new Vector3(0, yRange, -zRange));
        Gizmos.DrawLine(pos + new Vector3(0, yRange, -zRange), pos + new Vector3(0, yRange, zRange));
        Gizmos.DrawLine(pos + new Vector3(0, yRange, zRange), pos + new Vector3(0, -yRange, zRange));
        Gizmos.DrawLine(pos + new Vector3(0, -yRange, zRange), pos + new Vector3(0, -yRange, -zRange));
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
        shootEvery = shootEveryInitial;
        lastReset = Time.time;
        StartCoroutine(ShootRepeating());
    }

    private void Update() {
        shootEvery = shootEveryInitial * Mathf.Pow(0.5f, ((Time.time - lastReset) / shootEveryHalfLife));
    }

    public void Reset() {
        lastReset = Time.time;
    }

    IEnumerator ShootRepeating() {
        yield return new WaitForSeconds(shootEvery);
        while (true)
        {
            ShootRandom();
            yield return new WaitForSeconds(shootEvery);
        }
    }

    private void ShootRandom() {
        Vector3 from = transform.position + new Vector3(0, Random.Range(-yRange, yRange), Random.Range(-zRange, zRange));
        float goalSize = 10;
        Vector3 to = target.transform.position + new Vector3(0, Random.Range(-goalSize, goalSize), Random.Range(-goalSize, goalSize)); ;
        ShootFrom(from, to);
    }

    private void ShootFrom(Vector3 from, Vector3 to) {
        float vh = Random.Range(averageVh * 0.5f, averageVh * 1.5f);
        float x = to.x - from.x;
        float y = to.y - from.y;
        float z = to.z - from.z;
        float dh = Mathf.Sqrt(x * x + z * z);
        Vector3 towardTarget = new Vector3(x, 0, z).normalized;
        float g = -Physics.gravity.y;

        float t = dh / vh;
        float vy = (y / t) + 0.5f * g * t;

        Vector3 velocity = vh * towardTarget + vy * transform.up;

        GameObject newBullet = Instantiate(bullet, from, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = velocity;
    }
}
