using UnityEngine;

public class UpBoss : MonoBehaviour
{
    public Enemy enemy;
    public GameObject enemyTurel;
    // Update is called once per frame
    void Update()
    {
        enemy = GetComponent<Enemy>();
        if (enemy.health < enemy.maxHealth*50/100)
        {   
            
            enemyTurel.SetActive(true);
        }
    }
}
