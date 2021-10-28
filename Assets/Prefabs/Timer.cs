using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text timerText;
    public bool alive = true;
    void Update()
    {
        if (alive)
        {
            timerText.text = "TIME SURVIVED: " + Mathf.RoundToInt(Time.time);
        }
        
    }
}
