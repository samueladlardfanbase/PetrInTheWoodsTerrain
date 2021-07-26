﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
    float xRotation = 0f;
    public Transform Player, Camera;
    public float MouseSensitivity = 100f;
    Petrnavigation petrnavigation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        petrnavigation = GameObject.Find("Petr").GetComponent<Petrnavigation>();
    }
    void Update()
    {
        if (petrnavigation.petrstate != 2)
        {
            float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
            float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

            xRotation -= MouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            Camera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            Player.Rotate(Vector3.up * MouseX);
        }
        
        


    }
}
