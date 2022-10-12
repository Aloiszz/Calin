using System;
using System.Collections;
using Unity.Mathematics;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public SO_DestroyBullet destroyBullet_SO;
    
    public GameObject laser;
    [HideInInspector]public float velocityTop;
    [HideInInspector]public float velocityDown;
    [HideInInspector]public float velocityRight;
    [HideInInspector]public float velocityLeft;
    
    [HideInInspector]public Transform shotTop;
    [HideInInspector]public Transform shotDown;
    [HideInInspector]public Transform shotRight;
    [HideInInspector]public Transform shotleft;
    
    public static DestroyBullet instance;
    public bool canShoot = true;

    public Vector2 lastDirection;
    
    /*----------------------------------------------------------------*/
    [HideInInspector]public float number; // nombre de munitions instantié
    public int numberIndex;
    [HideInInspector]public float cadency; // cadence de tir
    public int cadencyIndex;
    [HideInInspector]public float velocity; // velocité de la munition
    public int velocityIndex;
    [HideInInspector]public int axeShoot;
    public int axeShootIndex;
    /*----------------------------------------------------------------*/
    [HideInInspector]public int levelPlayer; 
    [HideInInspector]public float bulletDamage; // direction du tir;
    
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
    
    public void SecureSO()
    {
        number = destroyBullet_SO.number[numberIndex];
        velocity = destroyBullet_SO.velocity[velocityIndex];
        cadency = destroyBullet_SO.cadency[cadencyIndex];
        axeShoot = destroyBullet_SO.axeShoot[axeShootIndex];
        bulletDamage = destroyBullet_SO.bulletDamage[levelPlayer];
    }

    private void Start()
    {
        SecureSO();
        shotTop = transform.Find("DestroyBullet/DestroyBulletTop");
        shotDown = transform.Find("DestroyBullet/DestroyBulletDown");
        shotleft = transform.Find("DestroyBullet/DestroyBulletLeft");
        shotRight = transform.Find("DestroyBullet/DestroyBulletRight");
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        Choose();
        yield return new WaitForSeconds(cadency);
        canShoot = true;
    }

    private void Update()
    {
        lastDirection = PlayerController.instance.lastMovement[^1];
        if (canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    void Choose()
    {
        switch (axeShoot)
        {
            case 1:
                ShootBase(); // tir une salve dans la direction du joueur
                break;
            case 2:
                Shoot2Axe(); // tir 2 salves dans la direction du joueur et la direction -1
                break;
            case 3:
                ShootAllAxe(); // tir 4 salve dans les 4 directions
                break;
        }
    }
    void ShootBase()
    {
        velocityTop = 0;
        velocityDown = 0;
        velocityRight = 0;
        velocityLeft = 0;
        if (lastDirection == Vector2.up)
        {
            velocityTop = velocity;
            var angle = 360 / number+1;
            
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(laser, shotTop.transform.position, quaternion.identity);

                var x = (Vector3)lastDirection + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle* number/2f), Vector3.forward) * Vector3.up;
                //Debug.Log((angle * i)+" "+((Vector3)lastDirection +(Quaternion.AngleAxis(angle * i, Vector3.forward) * Vector3.up)));
                spawnBullet.transform.up = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(spawnBullet.transform.up * velocityTop);
                
            }
        }
        if (lastDirection == Vector2.down)
        {
            velocityDown = -velocity;
            var angle = 360 / number+1;
            
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(laser, shotDown.transform.position, quaternion.identity);
                
                var x = (Vector3)lastDirection + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * -(Vector3.up);
                spawnBullet.transform.up = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(-spawnBullet.transform.up * velocityDown);
                
            }
        }
        if (lastDirection == Vector2.right)
        {
            velocityRight = velocity;
            var angle = 360 / (number+1);
            
            for (int i = 0; i <number; i++)
            {
                var spawnBullet = Instantiate(laser, shotRight.transform.position, quaternion.identity);
                
                var x = (Vector3)lastDirection + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * Vector3.right;
                spawnBullet.transform.right = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(spawnBullet.transform.right * velocityRight);
                
            }
        }
        if (lastDirection == Vector2.left)
        {
            velocityLeft = -velocity;
            var angle = 360 / (number+1);
            
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(laser, shotleft.transform.position, quaternion.identity);
                
                var x = (Vector3)lastDirection + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * -(Vector3.right);
                spawnBullet.transform.right = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(-spawnBullet.transform.right * velocityLeft);
                
            }
        }
    }

    void Shoot2Axe()
    {
        velocityTop = 0;
        velocityDown = 0;
        velocityRight = 0;
        velocityLeft = 0;
        if (lastDirection == Vector2.up || lastDirection == Vector2.down)
        {
            velocityDown = -velocity;
            velocityTop = velocity;

            var angle = 360 / (number+1);
            
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(laser, shotTop.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.up + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * (Vector3.up);
                spawnBullet.transform.up = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(spawnBullet.transform.up * velocityTop);
                
            }
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(laser, shotDown.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.down + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * -(Vector3.up);
                spawnBullet.transform.up = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(-spawnBullet.transform.up * velocityDown);
                
            }
        }
        if (lastDirection == Vector2.right || lastDirection == Vector2.left)
        {
            velocityRight = velocity;
            velocityLeft = -velocity;
            var angle = 360 / (number+1);
            
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(laser, shotRight.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.right+ Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * (Vector3.right);
                spawnBullet.transform.right = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(spawnBullet.transform.right * velocityRight);
            }
            
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(laser, shotleft.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.left + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * -(Vector3.right);
                spawnBullet.transform.right = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(-spawnBullet.transform.right * velocityLeft);
                
            }
        }
    }

    void ShootAllAxe()
    {
        velocityTop = 0;
        velocityDown = 0;
        velocityRight = 0;
        velocityLeft = 0;

        if (lastDirection == Vector2.up || lastDirection == Vector2.down || lastDirection == Vector2.right ||
            lastDirection == Vector2.left)
        {
            velocityDown = -velocity;
            velocityTop = velocity;
            velocityRight = velocity;
            velocityLeft = -velocity;
            
            var angle = 360 / (number+1);
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(laser, shotTop.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.up + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * (Vector3.up);
                spawnBullet.transform.up = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(spawnBullet.transform.up * velocityTop);
                
            }
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(laser, shotDown.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.down + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * -(Vector3.up);
                spawnBullet.transform.up = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(-spawnBullet.transform.up * velocityDown);
                
            }
            
            for (int i = 0; i <number; i++)
            {
                var spawnBullet = Instantiate(laser, shotRight.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.right + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * (Vector3.right);
                spawnBullet.transform.right = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(spawnBullet.transform.right * velocityRight);
                
            }
            
            for (int i = 0; i <number; i++)
            {
                var spawnBullet = Instantiate(laser, shotleft.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.left + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * -(Vector3.right);
                spawnBullet.transform.right = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(-spawnBullet.transform.right * velocityLeft);
                
            }
        }
    }
}
    
    