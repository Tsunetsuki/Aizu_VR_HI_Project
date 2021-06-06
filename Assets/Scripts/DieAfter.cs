using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfter : MonoBehaviour
{
    private float birth;
    public float dieAfterSec;
    void Start()
    {
        birth = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (birth + dieAfterSec < Time.time) Destroy(gameObject);
    }
}
