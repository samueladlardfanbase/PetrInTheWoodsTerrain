using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject torch;
    public GameObject radio;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && torch.GetComponent<Torchscript>().equiped == false)
        {
            torch.GetComponent<Torchscript>().Equip();
            
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            torch.GetComponent<Torchscript>().UnEquip();
        }


    }
}
