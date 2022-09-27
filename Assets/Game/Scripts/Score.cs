using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProgressBar = Michsky.UI.ModernUIPack.ProgressBar;
using TMPro;
using System;
public class Score : MonoBehaviour
{
    public int _score;
    public Text scoreDisplay;
    public ProgressBar myBar; // Your pb variable
    public TextMeshProUGUI lvl;
    private int currentLvl = 0;
    

    public void LateUpdate()
    {

        lvl.text = "Lv. " + currentLvl.ToString();
        scoreDisplay.text = "Kill: " + _score.ToString();
    }
    public void LvLUP()
    {        
         currentLvl += 1;
    }
    
    public void KillEnemy()
    {
        _score++;
    }
    
}
