using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerEventsHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void Red() {
        GetComponent<MeshRenderer>().material.color = Color.red;
        Debug.Log("Color: red");
    }
    public void Green() {
        GetComponent<MeshRenderer>().material.color = Color.green;
        Debug.Log("Color: green");
    }
    public void Blue() {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        Debug.Log("Color: blue");
    }
}