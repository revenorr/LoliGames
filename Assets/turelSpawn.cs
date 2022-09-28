using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turelSpawn : MonoBehaviour
{
    public GameObject Turel;
    public Transform Spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            Instantiate(Turel, Spawn.position, Spawn.rotation);
    }
}
