using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public SO_Shotgun shotgun_SO;
    
    [HideInInspector]public GameObject shotgunBullet;
    [HideInInspector]public GameObject shotTop;
    [HideInInspector]public GameObject shotDown;
    [HideInInspector]public GameObject shotRight;
    [HideInInspector]public GameObject shotleft;

    
    [HideInInspector]public float velocityX;
    [HideInInspector]public float velocityY;

    public static Shotgun instance;

    public Vector2 lastDirection;

    [Header("Variation Axe de tir")]
    public int variation;


    private void Awake()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        } 
    }

    private void Start()
    {
        InvokeRepeating(nameof(Choose),0, shotgun_SO.cadency[shotgun_SO.cadencyIndex]);
    }

    private void Update()
    {
        lastDirection = PlayerController.instance.lastMovement[^1];
    }

    void Choose()
    {
        switch (variation)
        {
            case 1:
                ShootBase(); // tir une salve dans la direction du joueur
                break;
            case 2:
                Shoot2Axe(); // tir 2 salves dans la direction du joueur et la direction -1
                break;
        }
    }

    void ShootBase()
    {
        velocityX = 0;
        velocityY = 0;
        if (lastDirection == Vector2.up)
        {
            velocityY = shotgun_SO.velocity[shotgun_SO.velocityIndex];
            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotTop.transform.position, quaternion.identity);
                switch (i)
                {
                    case 0:
                        //ShotgunBullet.instance.Shoot(lastDirection,velocityY, new Vector3(0,0,-90));
                        
                        spawnBullet.GetComponent<ShotgunBullet>().rb.AddForce(lastDirection * velocityY);
                        spawnBullet.GetComponent<ShotgunBullet>().transform.DORotate(new Vector3(0,0,-90), 0);
                        break;
                    case 1:
                        //ShotgunBullet.instance.Shoot(lastDirection,velocityY, new Vector3(0,0,0));
                        
                        spawnBullet.GetComponent<ShotgunBullet>().rb.AddForce(lastDirection * velocityY);
                        spawnBullet.GetComponent<ShotgunBullet>().transform.DORotate(new Vector3(0,0,-90), 0);
                        break;
                    case 2:
                        //ShotgunBullet.instance.Shoot(lastDirection,velocityY, new Vector3(0,0,90));
                        
                        spawnBullet.GetComponent<ShotgunBullet>().rb.AddForce(lastDirection * velocityY);
                        spawnBullet.GetComponent<ShotgunBullet>().transform.DORotate(new Vector3(0,0,-90), 0);
                        break;
                }
            }
        }
        if (lastDirection == Vector2.down)
        {
            velocityY = -shotgun_SO.velocity[shotgun_SO.velocityIndex];
            Instantiate(shotgunBullet, shotDown.transform.position, quaternion.identity);
        }
        if (lastDirection == Vector2.right)
        {
            velocityX = shotgun_SO.velocity[shotgun_SO.velocityIndex];
            Instantiate(shotgunBullet, shotRight.transform.position, quaternion.identity);
        }
        if (lastDirection == Vector2.left)
        {
            velocityX = -shotgun_SO.velocity[shotgun_SO.velocityIndex];
            Instantiate(shotgunBullet, shotleft.transform.position, quaternion.identity);
        }
    }

    void Shoot2Axe()
    {
        velocityX = 0;
        velocityY = 0;
        if (lastDirection == Vector2.up || lastDirection == Vector2.down)
        {
            velocityY = shotgun_SO.velocity[shotgun_SO.velocityIndex];
            Instantiate(shotgunBullet, shotTop.transform.position, quaternion.identity);
            Instantiate(shotgunBullet, shotDown.transform.position, quaternion.identity);
        }
        
        if (lastDirection == Vector2.right || lastDirection == Vector2.left)
        {
            velocityX = shotgun_SO.velocity[shotgun_SO.velocityIndex];
            Instantiate(shotgunBullet, shotRight.transform.position, quaternion.identity);
            Instantiate(shotgunBullet, shotleft.transform.position, quaternion.identity);
        }
    }
}  
