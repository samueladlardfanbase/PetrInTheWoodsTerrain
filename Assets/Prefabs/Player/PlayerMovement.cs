
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public variables
    public CharacterController Controller;
    public Transform camerapos;
    public GameObject Stamina;
    public GameObject Health;
    public GameObject Petr;
    public float Speed = 12f;
    public float lerpSpeed = 1;
    public float healthamount = 0.5f;
    //The variables that dictate how fast the stamina goes up or down
    public float StaminaReductionSpeed = 1;
    public float StaminaReplenishingSpeed = 1;
    //Normal variables
    float moveSpeed;
    float crouchHeight = 1.5f;
    float staminaamount = 0.25f;
    float t = 0;
    float t1 = 0;
    public bool issprinting = false;
    public bool iscrouching = false;

    Petrnavigation petrnavigation;
    private void Start()
    {
        //sets the defalt speed value
        moveSpeed = Speed;
        petrnavigation = Petr.GetComponent<Petrnavigation>();
    }

    void Update()
    {
        //stops the player from moving while a jump scare is happening
        if (petrnavigation.petrstate != 2)
        {
            //checks for inputs
            float X = Input.GetAxis("Horizontal");
            float Z = Input.GetAxis("Vertical");
            //turns the inputs into vectors that the player can move by
            Vector3 MoveZ = transform.forward * Z * moveSpeed * Time.deltaTime;
            Vector3 MoveX = transform.right * X * moveSpeed * Time.deltaTime;
            //move the player depending on the inputs
            Controller.Move(MoveZ);
            Controller.Move(MoveX);



            // calls the fucntions to sprint crouch and manage health
            Sprint();
            Crouch();
            Healthmanager();

            Noisemanager(X, Z);
        }
        
        
    }
    
    void Sprint()
    {
        
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) == false && staminaamount > 0)
        {
            if (t1 < 1)
            {
                t1 += Time.deltaTime * StaminaReductionSpeed;
            }
            issprinting = true;
            moveSpeed = 12;
        }
        else if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            moveSpeed = Speed;
            issprinting = false;
            if (t1 > 0 && Input.GetKey(KeyCode.LeftControl) != true)
            {
                t1 -= Time.deltaTime * StaminaReplenishingSpeed;
            }
        }
        staminaamount = Mathf.Lerp(0.25f, 0f, t1);
        Stamina.transform.localScale = new Vector3(staminaamount,0.05f,1);
    }

    
    void Crouch()
    {

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl) == false)
        {
            if (t < 1)
            {
                t += Time.deltaTime * lerpSpeed;
            }
            iscrouching = true;
            Controller.height = 1.25f;
            Controller.center = new Vector3(0,-0.37f,0);
            moveSpeed = 1;
            
        }
        else if (Input.GetKey(KeyCode.LeftControl) == false)
        {
            if (t > 0)
            {
                t -= Time.deltaTime * lerpSpeed;
                
            }
            iscrouching = false;
            Controller.height = 2f;
            Controller.center = new Vector3(0, 0, 0);
            moveSpeed = Speed;
            
        }
        crouchHeight = Mathf.Lerp(0.5f, -0.5f, t);
        camerapos.localPosition = new Vector3(camerapos.localPosition.x, crouchHeight, camerapos.localPosition.z);
        
    }

    
    void Noisemanager(float Xvelocity, float Yvelocity)
    {
        if (Xvelocity > 0 || Yvelocity > 0)
        {
            if (iscrouching == true)
            {
                petrnavigation.sound(10, transform.position);
            }
            else if(issprinting == true)
            {
                petrnavigation.sound(80, transform.position);
            }
            else
            {
                petrnavigation.sound(60, transform.position);
            }
        }
        else
        {
            petrnavigation.sound(25, transform.position);
        }
        
        
    }


    void Healthmanager()
    {
        Health.transform.localScale = new Vector3(healthamount, 0.05f, 0.5f);
    }



    void Die()
    {

    }


}
