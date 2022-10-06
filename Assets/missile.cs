using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public GameObject hitEffect;

    public int damage;
    [SerializeField] private float SphereRadius = 10;
    private LvlUp lvlUp;
    [SerializeField] private float bulletSpeed = 5;
    private LayerMask layer;

    private void Awake()
    {
        
        lvlUp = FindObjectOfType<LvlUp>();
        //damage = lvlUp.CurrentCausticDamage;
    }
    public void SetBullet(LayerMask layerMask, Vector3 direction)
    {
        layer = layerMask;
        Rigidbody body = GetComponent<Rigidbody>();
        body.useGravity = false;
        body.velocity = direction * bulletSpeed;
        transform.forward = direction;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            AoEDamage();
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);

        }
    }
    private void AoEDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, SphereRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<Enemy>())
            {
                collider.GetComponent<Enemy>().health -= damage;
            }
        }
    }
}