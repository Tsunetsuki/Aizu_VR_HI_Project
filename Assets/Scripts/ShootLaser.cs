using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public GameObject laserObj;
    public float laserDuration;

    private void Start() {
        laserObj.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            laserObj.SetActive(true);
            StartCoroutine(StopLaser());
        }
    }

    private IEnumerator StopLaser() {
        yield return new WaitForSeconds(laserDuration);
        laserObj.SetActive(false);

    }

    
}
