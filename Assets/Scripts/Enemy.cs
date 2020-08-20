using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navMesh;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        navMesh = GetComponent<NavMeshAgent>();
       
    }

    private void Update()
    {
        navMesh.SetDestination(player.transform.position);
    }

}
