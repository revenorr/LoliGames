using UnityEngine;
using System;
using System.Collections;

public class turelSpawn : MonoBehaviour
{
    public GameObject Turel;
    public Transform Spawn;
    private LvlUp LvlUp;
    [SerializeField]public float timeToResp = 30f;
    public float  destoy= 20f;
    public bool turelIsSpawn = false;
    


    void Update()
    {
        LvlUp= FindObjectOfType<LvlUp>();
        if (LvlUp.TurelSpawnBool == true && turelIsSpawn == false)
            {
            Debug.Log("turellllllll");
            StartCoroutine(TurelSpawnON());
            turelIsSpawn = true;
            }
              
            
    }
    /*public void TurelSpawn()
    {
        var newTurel = Instantiate(Turel, Spawn.position, Spawn.rotation);
        Destroy(newTurel, 5);
    }*/
    private IEnumerator TurelSpawnON()
    {
        while (true)
        {
            //Instantiate(Turel, Spawn.position, Spawn.rotation);
            //TurelSpawn();
            var newTurel = Instantiate(Turel, Spawn.position, Spawn.rotation);
            Destroy(newTurel, destoy);
            yield return new WaitForSeconds(timeToResp);
        }
    } 
}
