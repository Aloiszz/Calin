using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;
using Random = UnityEngine.Random;


public class Rush : MonoBehaviour
{
    public GameObject shotgunBullet;
    public GameObject rushXP;
    public SO_Rush rush_SO;
    public bool canShoot = true;

    //public static Rush instance;

    [Header("ScriptableObject")] 
    public int levelPlayer;
    public float life;
    public float velocity;
    public float numberBullet;
    public int xp;
    /*-------------------------------------------*/
    public float timeCooldown;
    public int timeCooldownIndex;
    public float timeDestroyBullet;

    
    /*private void Awake()
    {
        if (instance != null && instance != this) 
        {
            
        } 
        else 
        { 
            instance = this; 
        } 
    }*/

    private void Start()
    {
        //SecureSO();
    }

    public void SecureSO()
    {
        life = rush_SO.life[levelPlayer];
        velocity = rush_SO.velocity[levelPlayer];
        numberBullet = rush_SO.numberBullet[levelPlayer];
        xp = rush_SO.xp[levelPlayer];

        timeCooldown = rush_SO.timeCooldown[timeCooldownIndex];
        timeCooldownIndex = rush_SO.timeCooldownIndex;

        timeDestroyBullet = rush_SO.timeDestroyBullet;
    }
    
    private void Update()
    {
        OnSeePlayer();
        Death();
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        var angle = 360 / (numberBullet+1);
        for (int i = 0; i < numberBullet; i++)
        {
            GameObject projectile = Instantiate(shotgunBullet, transform.position, Quaternion.identity);
            
            var x = Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*numberBullet/2f), Vector3.forward) * Vector3.up;
            projectile.GetComponent<Rigidbody2D>().AddForce((PlayerController.instance.transform.position - x).normalized * velocity);
        }
        
        yield return new WaitForSeconds(timeCooldown);
        canShoot = true;
    }

    void OnSeePlayer()
    {
        if (canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    public void OnTouched()
    {
        life -= Shotgun.instance.bulletDamage;
    }

    void Death()
    {
        if (life <= 0)
        {
            Instantiate(rushXP, transform.position, quaternion.identity);
            SpecialEffectsHelper.Instance.Explosion(transform.position);
            Destroy(gameObject);
        }
        
    }
}
