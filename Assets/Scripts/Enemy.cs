using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;

    [SerializeField]
    private Transform target;

    public Player myPlayer;

    [SerializeField]
    private float displacementDist = 3f;

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (myPlayer.cubeCollected)
            {
                MoveFromPlayer();
            }
            else
            {
                MoveToPlayer();
            }
                
        }
    }

    private void MoveToPlayer()
    {
        myNavMeshAgent.SetDestination(target.position);
    }

    private void MoveFromPlayer()
    {
        Vector3 normDir = (target.position - transform.position).normalized;

        myNavMeshAgent.SetDestination(transform.position - (normDir * displacementDist));
    }
}
