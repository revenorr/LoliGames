using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float bulletLifeTime;
    public int damage =1;
    //public LayerMask whatIsSolid;
    

    private void Awake()
    {
        Destroy(this.gameObject, bulletLifeTime);
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
   

}
