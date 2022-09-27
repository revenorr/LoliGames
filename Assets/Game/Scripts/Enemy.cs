using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int health;
    private Score sm;
    public GameObject DropEXP;
    
    public TextMeshPro HealthText;

    private void Start()
    {
        sm = FindObjectOfType<Score>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    // Update is called once per frame
    private void Update()
    {
        HealthText.text = "HP: " + health.ToString();
        if (health <= 0)
        {
            GameObject dropEXP = Instantiate(DropEXP, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log("Враг Убит");
            sm.KillEnemy();
        }
           
            
    }

}
