using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public GameObject radio;
    public GameObject alarmLight;
    public GameObject petr;
    public Transform petrvector;
    public Transform player;
    void Update()
    {
        Vector3 difference = petr.transform.position - player.position;
        float radAngle = 0;
        Vector3 direction = difference;
       
        
        radAngle = Mathf.Atan2(direction.x, direction.z);
        
        
        
        float degAngle = radAngle * Mathf.Rad2Deg;
        float angle = Mathf.RoundToInt(degAngle - player.rotation.eulerAngles.y);
        print(angle);
        
        if ((angle < -315 || angle > -45 && angle < 0) || angle < 45 && angle > 0 || angle == 0)
        {
            alarmLight.SetActive(true);
        }
        else
        {
            alarmLight.SetActive(false);
        }

    }


   
}
