using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private Score sm;
    public GameObject DropEXP;
    private enemyUP enemyUP;
    public TextMeshPro HealthText;
    public int healthUP;
    private void Awake()
    {
        GlobalEventManager.OnEnemyUP += EnemyHealsUP;
        sm = FindObjectOfType<Score>();
        health = maxHealth;
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
    public void EnemyHealsUP()
    {
        maxHealth += healthUP;
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnEnemyUP -= EnemyHealsUP;
    }


}

