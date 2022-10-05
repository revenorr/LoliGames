﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public GameObject die;
    private NavMeshAgent _agent;
    public int damage;
    public GameObject TakeDamageSound;
    public Animator animator;
    private bool onTrigerEnter = false;


    [SerializeField] PlayerController _player;

    [SerializeField]
    public float _distanseToPlayer = 10f;

    private const float EPSILON = 0.1f;
    // Start is called before the first frame update
    private void Awake()
    {
        GlobalEventManager.OnEnemyUP += EnemySpeedUP;
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = speed;

    }
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject col = collider.gameObject;

        PlayerController playerTakeDamage = col.GetComponent<PlayerController>();


        if (playerTakeDamage != null )
        {
            playerTakeDamage.health -= damage;
            GameObject effect = Instantiate(die, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Instantiate(TakeDamageSound, transform.position, Quaternion.identity);
            animator.SetTrigger("Damage");
            onTrigerEnter = true;
            StartCoroutine(timeEffect(1f));
        }

    }
    IEnumerator timeEffect(float time)
    {
        yield return new WaitForSeconds(time);
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
        
        float dist = Vector3.Distance(_player.transform.position, transform.position);
        if (dist < _distanseToPlayer && onTrigerEnter == false)
        {
            Vector3 playerPos = _player.transform.position;
            _agent.SetDestination(playerPos);
        }
        
        //transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    public void EnemySpeedUP()
    {
        speed += 1;
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnEnemyUP -= EnemySpeedUP;
    }

}
