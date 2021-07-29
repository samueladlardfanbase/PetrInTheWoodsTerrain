using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchscript : MonoBehaviour
{
    public GameObject Torch;
    bool equiped = false;
    void Update()
    {
        if (Input.GetKeyDown("1") && equiped == false)
        {
            Torch.SetActive(true);
            equiped = true;
        }
        else if(Input.GetKeyDown("1") && equiped == true)
        {
            equiped = false;
            Torch.SetActive(false);
        }
    }
}
