using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Michsky.UI.ModernUIPack;
using UnityEngine.UI;

public class LvlUp : MonoBehaviour
{
    public GameObject[] G_Object;
    public GameObject[] S_Object;

    public List<int> TakeList = new List<int>();

    private int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        TakeList = new List<int>(new int[G_Object.Length]);
        for (int i = 0; i < G_Object.Length; i++)
        {
            randomNumber = UnityEngine.Random.Range(1, (S_Object.Length) + 1);
            while (TakeList.Contains(randomNumber))
            {
                randomNumber = UnityEngine.Random.Range(1, (S_Object.Length) + 1);
            }
            TakeList[i] = randomNumber;
            //G_Object[i] = S_Object[(TakeList[i] - 1)]; тут где то должно что то произойти 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
