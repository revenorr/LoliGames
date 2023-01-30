using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyUP : MonoBehaviour
{
    [SerializeField] private float upDelay=5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyTimerCur());
    }


   
    
    private IEnumerator enemyTimerCur()        
    {
        while (true)
        {
            
            yield return new WaitForSeconds(upDelay);
            GlobalEventManager.EnemyUPEvent();
            Debug.Log("Враг Усилен");

        }
    }
}
