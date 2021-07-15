
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController Controller;
    public Transform camerapos;
    public GameObject Stamina;
    public GameObject Health;
    public float Speed = 12f;
    public float lerpSpeed = 1;
    public float StaminaReductionSpeed = 1;
    public float StaminaReplenishingSpeed = 1;
    float moveSpeed;
    float crouchHeight = 2;
    float staminaamount = 0.25f;
    public float healthamount = 0.5f;
    float t = 0;
    float t1 = 0;

    private void Start()
    {
        moveSpeed = Speed;
        t = Mathf.Clamp(t, 0, 1);
        t1 = Mathf.Clamp(t, 0, 1);
    }

    void Update()
    {
        
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        Vector3 MoveZ = transform.forward * Z * moveSpeed * Time.deltaTime;
        Vector3 MoveX = transform.right * X * moveSpeed * Time.deltaTime;
        Controller.Move(MoveZ);
        Controller.Move(MoveX);

        Sprint();
        Crouch();
        Healthmanager();
        
    }
    
    void Sprint()
    {
        
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) == false && staminaamount > 0)
        {
            if (t1 < 1)
            {
                t1 += Time.deltaTime * StaminaReductionSpeed;
            }
            moveSpeed = 12;
        }
        else if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            moveSpeed = Speed;

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
            Controller.height = 2f;
            Controller.center = new Vector3(0, 0, 0);
            moveSpeed = Speed;
            
        }
        crouchHeight = Mathf.Lerp(0.5f, -0.25f, t);
        camerapos.localPosition = new Vector3(camerapos.localPosition.x, crouchHeight, camerapos.localPosition.z);
        
    }

    void Healthmanager()
    {
        Health.transform.localScale = new Vector3(healthamount, 0.05f, 0.5f);
    }



    void Die()
    {

    }


}
