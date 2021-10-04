using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchscript : MonoBehaviour
{
    public GameObject Torchbit1;
    public GameObject Torchbit2;
    public GameObject Torchbit3;
    public GameObject torchlight;
    public Animator anim;
    
    bool equiped = false;
    bool torchon = false;
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
            torchlight.SetActive(false);
            torchon = false;
        }

        if (equiped == true && Input.GetMouseButtonDown(0) && torchon == false)
        {

            anim.Play("Cylinder_001|Cylinder_001Action");
            torchlight.SetActive(true);
            torchon = true;
        }
        else if(equiped == true && Input.GetMouseButtonDown(0) && torchon == true)
        {
            
            anim.Play("Cylinder_001|Cylinder_001Action");
            torchlight.SetActive(false);
            torchon = false;
        }
    }

    
    

}
