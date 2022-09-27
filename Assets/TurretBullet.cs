using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

[RequireComponent(typeof(Rigidbody))]

public class TurretBullet : MonoBehaviour
{

    [SerializeField] private int damage = 10;
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
    void OnCollisionEnter(Collision collision)
    {
        GameObject col = collision.gameObject;
        Enemy enemyInfo = col.GetComponent<Enemy>();
        if (enemyInfo != null)
            enemyInfo.health -= damage;

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ground")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }

    }

    /*void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            if (((1 << other.gameObject.layer) & layer) != 0)
            {
                Enemy _damage = FindObjectOfType<Enemy>();
                _damage.health -= damage;
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 5f);
                Destroy(gameObject);
            }
        }
      
    }*/

}

