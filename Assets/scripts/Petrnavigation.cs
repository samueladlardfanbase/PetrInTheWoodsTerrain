using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Petrnavigation : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent petrAgent;
    void Update()
    {
        
        petrAgent.SetDestination(player.position);
    }
}
