using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;
using Random = UnityEngine.Random;
using DG.Tweening;


public class Rush : MonoBehaviour
{
    public GameObject shotgunBullet;
    public GameObject rushXP;
    public ParticleSystem destruction;
    public SO_Rush rush_SO;
    public bool canShoot = true;

    //public static Rush instance;

    [Header("ScriptableObject")] 
    //public int levelPlayer;
    public float life;
    public float velocity;
    public float numberBullet;
    public int xp;
    public int damage;
    /*-------------------------------------------*/
    public float timeCooldown;
    public int timeCooldownIndex;
    public float timeDestroyBullet;


    public bool isShooting = true;
    public bool isWalking;
    private void Start()
    {
        life = rush_SO.life[XP_Manager.instance.levelPlayer];
        velocity = rush_SO.velocity[XP_Manager.instance.levelPlayer];
        numberBullet = rush_SO.numberBullet[XP_Manager.instance.levelPlayer];
        xp = rush_SO.xp[XP_Manager.instance.levelPlayer];
        damage = rush_SO.damage[XP_Manager.instance.levelPlayer];

        timeCooldown = rush_SO.timeCooldown[XP_Manager.instance.levelPlayer];
        timeCooldownIndex = rush_SO.timeCooldownIndex;

        timeDestroyBullet = rush_SO.timeDestroyBullet;
    }

    public void SecureSO()
    {
        life = rush_SO.life[XP_Manager.instance.levelPlayer];
        velocity = rush_SO.velocity[XP_Manager.instance.levelPlayer];
        numberBullet = rush_SO.numberBullet[XP_Manager.instance.levelPlayer];
        xp = rush_SO.xp[XP_Manager.instance.levelPlayer];
        damage = rush_SO.damage[XP_Manager.instance.levelPlayer];

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
            
            var x = Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*numberBullet/2f), Vector3.forward) * (PlayerController.instance.transform.position - transform.position).normalized;
            projectile.transform.up = x;
            projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.up  * velocity);
            //projectile.GetComponent<Rigidbody2D>().AddForce((PlayerController.instance.transform.position - transform.position).normalized * velocity);
        }
        
        yield return new WaitForSeconds(timeCooldown);
        canShoot = true;
    }

    void OnSeePlayer()
    {
        if (isShooting)
        {
            if (canShoot)
            {
                StartCoroutine(Shoot());
            }
        }
        
    }

    public void OnTouched()
    {
        life -= Shotgun.instance.bulletDamage;
        //DOColor
    }

    void Death()
    {
        if (life <= 0)
        {
            Instantiate(rushXP, transform.position, quaternion.identity).GetComponent<XpRush>().xp = xp;
            Instantiate(destruction, transform.position, quaternion.identity);
            //SpecialEffectsHelper.Instance.Explosion(transform.position);
            Destroy(gameObject);
        }
        
    }
}
