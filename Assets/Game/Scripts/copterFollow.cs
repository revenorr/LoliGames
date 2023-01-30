using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class copterFollow : MonoBehaviour
{
    private NavMeshAgent _agent;
    public Transform target;
    public float minDistanceSqr;


    // Start is called before the first frame update
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            var destPosition = target.position;
            var sqrDistance = (transform.position - destPosition).sqrMagnitude;

            _agent.destination = destPosition;
            _agent.isStopped = (sqrDistance <= minDistanceSqr);
        }
        else
        {
            _agent.isStopped = true;
        }
    }
}
