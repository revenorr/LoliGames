using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //public GameObject animator1;
    public ParticleSystem ShootParticles;
    private PlayerController playerController;
    public bool speedSlow;
    
    public Transform firePoint;
    public Transform firePointFlyGan1;
    public Transform firePointFlyGan2;
    public int flyGunOn = 0;
    public GameObject bulletPrefab;
    public float RateOfFire = 0.5f;
    private float _rateOfFire;
    public float bulletForce = 20f;
    public Animator animator;
    public Animator animatorFlyGun;
    public AudioSource shootSound;
    public AudioClip impact;
    public AudioSource reloadSoundOut;
    public AudioSource reloadSoundIn;

    public int allAmmo;
    public int currentAmmo;
    public float reloadTime = 2f;
    private bool onReload = false;
    public GameObject reloadUI;


    [SerializeField]
    private TextMeshProUGUI ammoCount;

    void Start()
    {
        animator = animator.GetComponent<Animator>();
        animatorFlyGun = animatorFlyGun.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (_rateOfFire <= RateOfFire)
        _rateOfFire += Time.deltaTime;
        if (Input.GetButton("Fire1") & _rateOfFire > RateOfFire & currentAmmo > 0 & onReload == false)
        {
            _rateOfFire = 0;
            Shoot();
            FlyGanShoot();
            animator.SetBool("Fire 0", true);
            if (flyGunOn >= 1)
                animatorFlyGun.SetBool("Fire", true);
            speedSlow = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            speedSlow = false;
            animator.SetBool("Fire 0", false);
            if (flyGunOn >= 1)
                animatorFlyGun.SetBool("Fire", false);
        }
        ammoCount.text ="Ammo: " + currentAmmo + " / " + allAmmo;
        


        if (Input.GetKeyDown(KeyCode.R) || currentAmmo == 0 & onReload == false)
        {
            StartReload();
            speedSlow = false;
        }
            
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward*bulletForce, ForceMode.Impulse);
        ShootParticles.Play();
        currentAmmo-=1;
        shootSound.PlayOneShot(impact, 0.7f);
    }
    public void StartReload()
    {
        onReload = true;
        Invoke(nameof(Reload), reloadTime);   
        reloadSoundOut.Play();
        reloadSoundIn.PlayDelayed(reloadTime-1f);
        reloadUI.SetActive(true);
        animator.SetBool("Fire 0", false);
        animator.SetBool("Reload", true);
        if (flyGunOn >= 1) animatorFlyGun.SetBool("Fire", false);
    }
    public void Reload()
    {
        currentAmmo = allAmmo;
        onReload = false;
        reloadUI.SetActive(false);
        animator.SetBool("Reload", false);

        
    }
    void FlyGanShoot()
    {
        if (flyGunOn >= 1)
        {
            GameObject bullet1 = Instantiate(bulletPrefab, firePointFlyGan1.position, firePointFlyGan1.rotation);
            Rigidbody rb1 = bullet1.GetComponent<Rigidbody>();
            rb1.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            
            if (flyGunOn > 1)
            {
                GameObject bullet2 = Instantiate(bulletPrefab, firePointFlyGan2.position, firePointFlyGan2.rotation);
                Rigidbody rb2 = bullet2.GetComponent<Rigidbody>();
                rb2.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            }

        }
        

       
    }
}
