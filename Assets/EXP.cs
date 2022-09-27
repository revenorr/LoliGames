using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using ProgressBar = Michsky.UI.ModernUIPack.ProgressBar;

public class EXP : MonoBehaviour
{
    //private SphereCollider turretTrigger;
    //public LayerMask layerMask;
    public ProgressBar myBar; // Your pb variable

    private Transform player;
    public float speed;
    public float exp = 1f;
    private bool getEXP = false;
    // Start is called before the first frame update
    void Awake()
    {     
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if(getEXP == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (transform.position == player.position)
            {

                myBar.currentPercent += exp;
                getEXP = false;
                Destroy(gameObject);
            }
        }
    }
    //void OnTriggerStay(Collider other)
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            getEXP=true;

        }
    }

    
}
