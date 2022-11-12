using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Animator animator;
    private bool onTrigerEnter = false;
    public SphereCollider sphereCollider;
    private BossFollow bossFollow;



    void OnTriggerEnter(Collider collider)
    {
        GameObject col = collider.gameObject;

        PlayerController playerTakeDamage = col.GetComponent<PlayerController>();


        if (playerTakeDamage != null && onTrigerEnter == false)
        {
            bossFollow = FindObjectOfType<BossFollow>();
            animator.SetTrigger("Attack2");
            onTrigerEnter = true;
            StartCoroutine(timeEffect(1.8f));
            sphereCollider.radius = 0;
            bossFollow.speed = 0f;
        }
    }

    IEnumerator timeEffect(float time)
    {
        yield return new WaitForSeconds(time);
        bossFollow.speed = bossFollow.normalSpeed;
        yield return new WaitForSeconds(3);
        sphereCollider.radius = 3;
        onTrigerEnter = false;
        
    }

}
