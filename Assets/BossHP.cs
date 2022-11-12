using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossHP : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private Score sm;
    public GameObject DropEXP;
    private enemyUP enemyUP;
    public TextMeshPro HealthText;
    public GameObject EnemyPrefab;
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
            Destroy(EnemyPrefab);
            Debug.Log("Враг Убит");
            sm.KillEnemy();
        }


    }
    public void EnemyHealsUP()
    {
        maxHealth += 20;
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnEnemyUP -= EnemyHealsUP;
    }


}
