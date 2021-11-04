using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Petrnavigation : MonoBehaviour
{
    //petrs mesh
    public GameObject petrmesh;
    //The player
    public Transform player;
    //The player's camera
    public Transform playerCamera;
    //The postion petr will follow when he is hunting the player 
    public Transform playerFollowPostion;
    //the navmesh agent of petr
    public NavMeshAgent petrAgent;
    //a light so the player will see petr's face when he kills
    public GameObject faceLight;
    public AudioSource jumpScareSound; 
    //the maximum range petr will search around sounds
    public float searchRange = 100;
    float searchposx;
    float searchposz;

    public GameObject timer;

    float nextSound;
    public float SoundDelay = 5;

    //the destination petr will go to
    public Vector3 targetDestination;
    PlayerMovement playerMovement;
    public int petrstate = 0;
    //0 = search for player
    //1 = Hunt the player
    //2 = Kill the player

    
    private void Awake()
    {
        playerMovement = player.gameObject.GetComponent<PlayerMovement>();
        
    }


    private void Update()
    {
        if (petrstate != 2)
        {
            Currentsate();
        }
        
        if (petrstate == 0)
        {
            targetDestination = new Vector3(searchposx, transform.position.y, searchposz);
        }
        else if(petrstate == 1)
        {
            Hunting();
            
            Invoke("JumpScare", 10);
        }
        
        petrAgent.SetDestination(targetDestination);
    }

    void Hunting()
    {
        petrAgent.speed = 100;
        petrmesh.SetActive(false);
        jumpScareSound.Play();
        targetDestination = playerFollowPostion.position;
    }

    void JumpScare()
    {
        faceLight.SetActive(true);
        petrmesh.SetActive(true);
        petrAgent.speed = 30;
        petrstate = 2;
        targetDestination = player.position;
        playerCamera.LookAt(new Vector3(transform.position.x, playerCamera.position.y, transform.position.z));
        timer.GetComponent<Timer>().alive = false;
    }
    void Currentsate()
    {
         //makes petr hunt the player if he is within a certain distance of the player
        // the distance changes depending on what the player is doing
        if (Vector3.Distance(player.position,transform.position) <= 5 && playerMovement.iscrouching == true)
        {
            petrstate = 1;
        }
        else if(Vector3.Distance(player.position, transform.position) <=  30 && playerMovement.issprinting == false)
        {
            petrstate = 1;
        }
        else if (Vector3.Distance(player.position, transform.position) <= 40 && playerMovement.issprinting == true)
        {
            petrstate = 1;
        }
    }
    public void sound(int soundlevel,Vector3 soundorigin)
    {

        if (nextSound < Time.time)
        {
            float distancefromsound = Vector3.Distance(soundorigin, transform.position);
            searchposx = soundorigin.x + Random.Range(-searchRange + soundlevel, searchRange - soundlevel);
            searchposz = soundorigin.z + Random.Range(-searchRange + soundlevel, searchRange - soundlevel);
            nextSound = Time.time + SoundDelay;
        }
        
    }

}
