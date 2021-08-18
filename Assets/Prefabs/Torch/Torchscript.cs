using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchscript : MonoBehaviour
{
    public GameObject Torchbit1;
    public GameObject Torchbit2;
    public GameObject Torchbit3;
    public Animator anim;
    bool equiped = false;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown("1") && equiped == false)
        {
            Torchbit1.GetComponent<MeshRenderer>().enabled = true;
            Torchbit2.GetComponent<MeshRenderer>().enabled = true;
            Torchbit3.GetComponent<MeshRenderer>().enabled = true;
            equiped = true;
        }
        else if(Input.GetKeyDown("1") && equiped == true)
        {
            equiped = false;
            Torchbit1.GetComponent<MeshRenderer>().enabled = false;
            Torchbit2.GetComponent<MeshRenderer>().enabled = false;
            Torchbit3.GetComponent<MeshRenderer>().enabled = false;
        }

        if (equiped == true && Input.GetMouseButtonDown(0))
        {
            anim.Play("Cylinder_001|Cylinder_001Action");
        }
    }
}
