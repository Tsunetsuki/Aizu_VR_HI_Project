using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalCounter : MonoBehaviour
{

    public TextMeshProUGUI text;
    
    void Start()
    {
        
    }

    public void DisplayNewGoals(int goals) {
        StopAllCoroutines();
        text.text = "" + goals;
        StartCoroutine(DeleteText());
    }

    private IEnumerator DeleteText() {
        yield return new WaitForSeconds(.5f);
        text.text = "";
    }
}
