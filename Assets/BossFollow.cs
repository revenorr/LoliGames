using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BossFollow : MonoBehaviour
{
    public float speed;
    private NavMeshAgent _agent;
    public int damage;
    public Animator animator;
    private bool onTrigerEnter = false;
    public float forseSpeed = 50;
    public float normalSpeed= 2;
    public SphereCollider sphereCollider;
    [SerializeField] PlayerController _player;
    public float chargeCooldown;

    [SerializeField]
    public float _distanseToPlayer = 10f;

    private const float EPSILON = 0.1f; 
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent = GetComponent<NavMeshAgent>();
    }
    //private void OnTriggerStay(Collider collider)

    void OnTriggerEnter(Collider collider)
    {
        GameObject col = collider.gameObject;

        PlayerController playerTakeDamage = col.GetComponent<PlayerController>();


        if (playerTakeDamage != null && onTrigerEnter == false)
        {
            speed = forseSpeed;
            animator.SetBool("Attack1", true);
            animator.SetTrigger("Attack");
            onTrigerEnter = true;
            StartCoroutine(timeEffect(1f));
            sphereCollider.radius = 0;
            _agent.angularSpeed = 0;
        }
    }

    IEnumerator timeEffect(float time)
    {
        yield return new WaitForSeconds(time);
        speed = normalSpeed;
        _agent.angularSpeed = 120;
        yield return new WaitForSeconds(chargeCooldown);
        sphereCollider.radius = 1;
        onTrigerEnter = false;

    }


    private bool IsNavMeshMoving
    {
        get
        {
            return _agent.velocity.magnitude > EPSILON;
        }
    }
    // Update is called once per frame
    void Update()
    {
        _agent.speed = speed;
        float dist = Vector3.Distance(_player.transform.position, transform.position);
        if (dist < _distanseToPlayer)
        {
            Vector3 playerPos = _player.transform.position;
            _agent.SetDestination(playerPos);
        }

    }



}


