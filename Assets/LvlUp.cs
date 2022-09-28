using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Michsky.UI.ModernUIPack;
using UnityEngine.UI;

public class LvlUp : MonoBehaviour
{
    public RectTransform[] G_Object;
    public GameObject[] S_Object;
    public RectTransform Canvas3;
    public GameObject Canvas3obj;
    //public GameObject bullet;
    public List<int> TakeList = new List<int>();
    private Shooting sh;
    private PlayerController playerController;
    //public Bullet bullet;
    private turelSpawn turelSpawn;
    private int randomNumber;
    public static bool GameIsPaused = false;
    public bool TurelSpawnBool = false;
    public int bulletDamage = 10;
    // Start is called before the first frame update
    void Start()
    {

        Canvas3=GetComponent<RectTransform>();
        GlobalEventManager.OnLvlUP += LvLUpOption;
        TurelSpawnBool = false;
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnLvlUP -= LvLUpOption;
    }

    //рандомный вывод кнопок
    public void LvLUpOption()
    {
        Pause();
        Debug.Log("Улучшение");
        
        //playerController = FindObjectOfType<PlayerController>();
        TakeList = new List<int>(new int[G_Object.Length]);
            for (int i = 0; i < G_Object.Length; i++)
            {
                randomNumber = UnityEngine.Random.Range(1, (S_Object.Length) + 1);
                while (TakeList.Contains(randomNumber))
                {
                    randomNumber = UnityEngine.Random.Range(1, (S_Object.Length) + 1);
                }
                TakeList[i] = randomNumber;
       
                var newbutton = Instantiate(S_Object[(TakeList[i] - 1)], G_Object[i].transform.position, G_Object[i].transform.rotation, Canvas3);
                Destroy(newbutton,0.2f);

        }
        
    }
    public void Resume()
    {
        //Canvas3obj.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    void Pause()
    {
        //Canvas3obj.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void destroyButton()
    {
        
    }
    //Улучшения
    public void PlayerSpeedUP()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.Speed += playerController.Speed*10/100;
        playerController.saveSpeed += playerController.saveSpeed * 10/100;
        Debug.Log("Увеличение скорости передвижения");
        Resume();
    }
    public void RateOfFireUP()
    {
        sh = FindObjectOfType<Shooting>();
        sh.RateOfFire -= sh.RateOfFire * 10 / 100;
        Debug.Log("Увеличение скорости стрельбы");
        Resume();
    }
    public void DamageUP()
    {
        //bullet = GetComponent<Bullet>();
        //bullet = FindObjectOfType<Bullet>();
        bulletDamage += 5;
        Debug.Log("Увеличение урона стрельбы");
        Resume();
    }
    public void TurelSpawn()
    {
        TurelSpawnBool = true;
        turelSpawn = FindObjectOfType<turelSpawn>();       
        if (turelSpawn.turelIsSpawn == true) turelSpawn.timeToResp -= turelSpawn.timeToResp * 10 / 100;
        Debug.Log("Получение турели");
        Resume();
    }
    public void AmmoUP()
    {
        sh = FindObjectOfType<Shooting>();
        sh.allAmmo += 10;
        Debug.Log("Увеличение количества патронов");
        Resume();
    }
    public void ReloadUP()
    {
        sh = FindObjectOfType<Shooting>();
        sh.reloadTime -= sh.reloadTime * 10 / 100;
        Debug.Log("Уменьшение перезарядки");
        Resume();
    }

}
