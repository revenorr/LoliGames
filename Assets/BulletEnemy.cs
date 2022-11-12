using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public GameObject die;
    public int damage = 1;
    public GameObject TakeDamageSound;
    public Animator animator;

    [SerializeField] PlayerController _player;
    [SerializeField] private float bulletSpeed = 5;
    private LayerMask layer;
    public GameObject hitEffect;
    public float bulletLifeTime;
    private void Awake()
    {
        Destroy(this.gameObject, bulletLifeTime);
    }
    public void SetBullet(LayerMask layerMask, Vector3 direction)
    {
        layer = layerMask;
        Rigidbody body = GetComponent<Rigidbody>();
        body.useGravity = false;
        body.velocity = direction * bulletSpeed;
        transform.forward = direction;
    }
    void OnTriggerEnter(Collider collider)
    {
        GameObject col = collider.gameObject;
        Collider currentCol = GetComponent<Collider>();
        currentCol.GetComponent<Collider>();

        PlayerController playerTakeDamage = col.GetComponent<PlayerController>();


        if (playerTakeDamage != null)
        {

            playerTakeDamage.health -= damage;
            GameObject effect = Instantiate(die, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Instantiate(TakeDamageSound, transform.position, Quaternion.identity); ;
            animator.SetTrigger("Damage");
            currentCol.enabled = false;
            Invoke(nameof(currentColEnable), 1f);
            Destroy(this.gameObject);
        }

    }
    private void currentColEnable()
    {
        Collider currentCol = GetComponent<Collider>();
        currentCol.GetComponent<Collider>();
        currentCol.enabled = true;
    }



}

