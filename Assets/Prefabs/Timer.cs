using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text timerText;
    void Update()
    {
        timerText.text = "TIME SURVIVED: " + Mathf.RoundToInt(Time.time); 
    }
}
