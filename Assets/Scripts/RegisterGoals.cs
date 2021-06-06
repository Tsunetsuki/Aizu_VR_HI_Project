using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterGoals : MonoBehaviour
{
    int goals;
    public GameObject particleSys;
    public UnityEngine.UI.Text goalText;
    public AudioSource audioSource;
    public Transform playerTransform;

    void Start()
    {
        ResetGoals();
    }

    public void ResetGoals() {
        goals = 0;
        UpdateText();
    }

    private void UpdateText() {
        StopAllCoroutines();
        if (playerTransform.localEulerAngles.z > 80 && playerTransform.localEulerAngles.z < 150)
        {
            goalText.text = "Reset";
        }
        else
        {
            goalText.text = "" + goals;
        }
        particleSys.SetActive(true);
        StartCoroutine(StopPartSys());
    }

    private void OnTriggerEnter(Collider other) {
        goals++;
        UpdateText();
        audioSource.Play();
    }

    private IEnumerator StopPartSys() {
        yield return new WaitForSeconds(1);
        particleSys.SetActive(false);
    }
}
