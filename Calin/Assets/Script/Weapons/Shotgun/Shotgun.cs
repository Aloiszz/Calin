using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEditor.Timeline;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

public class Shotgun : MonoBehaviour
{
    public SO_Shotgun shotgun_SO;
    
    [HideInInspector]public GameObject shotgunBullet;
    public Transform shotTop;
    public Transform shotDown;
    public Transform shotRight;
    public Transform shotleft;

    
    [HideInInspector]public float velocityTop;
    [HideInInspector]public float velocityDown;
    [HideInInspector]public float velocityRight;
    [HideInInspector]public float velocityLeft;

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
        shotTop = transform.Find("ShotGun/ShotgunPointTop");
        shotDown = transform.Find("ShotGun/ShotgunPointDown");
        shotleft = transform.Find("ShotGun/ShotgunPointLeft");
        shotRight = transform.Find("ShotGun/ShotgunPointRight");
        
        InvokeRepeating(nameof(Choose),0, shotgun_SO.cadency[shotgun_SO.cadencyIndex]);
        PlayerController.instance.lastMovement.Add(Vector2.zero);
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
            velocityTop = shotgun_SO.velocity[shotgun_SO.velocityIndex];
            var angle = 360 / (shotgun_SO.number[shotgun_SO.numberIndex]+1);
            
            for (int i = 0; i < shotgun_SO.number[shotgun_SO.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotTop.transform.position, quaternion.identity);

                var x = (Vector3)lastDirection + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*shotgun_SO.number[shotgun_SO.numberIndex]/2f), Vector3.forward) * Vector3.up;
                //Debug.Log((angle * i)+" "+((Vector3)lastDirection +(Quaternion.AngleAxis(angle * i, Vector3.forward) * Vector3.up)));
                spawnBullet.transform.up = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(spawnBullet.transform.up * velocityTop);
                
                
                /*switch (i)
                {
                    case 1:
                        var x = lastDirection + new Vector2(-1/shotgun_SO.number[shotgun_SO.numberIndex+1], lastDirection.y);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(x.normalized * velocityTop);
                        break;
                    case 2:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(lastDirection * velocityTop);
                        break;
                    case 3:
                        var y = lastDirection + new Vector2(1/shotgun_SO.number[shotgun_SO.numberIndex+1], lastDirection.y).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(y.normalized * velocityTop);
                        break;
                }*/
            }
        }
        if (lastDirection == Vector2.down)
        {
            velocityDown = -shotgun_SO.velocity[shotgun_SO.velocityIndex];
            var angle = 360 / (shotgun_SO.number[shotgun_SO.numberIndex]+1);
            
            for (int i = 0; i < shotgun_SO.number[shotgun_SO.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotDown.transform.position, quaternion.identity);
                
                var x = (Vector3)lastDirection + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*shotgun_SO.number[shotgun_SO.numberIndex]/2f), Vector3.forward) * -(Vector3.up);
                spawnBullet.transform.up = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(-spawnBullet.transform.up * velocityDown);
                /*switch (i)
                {
                    case 0:
                        var x = lastDirection + new Vector2(-1, lastDirection.y);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-x.normalized * velocityDown);
                        break;
                    case 1:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-lastDirection * velocityDown);
                        break;
                    case 2:
                        var y = lastDirection + new Vector2(1, lastDirection.y).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-y.normalized * velocityDown);
                        break;
                }*/
            }
        }
        if (lastDirection == Vector2.right)
        {
            velocityRight = shotgun_SO.velocity[shotgun_SO.velocityIndex];
            var angle = 360 / (shotgun_SO.number[shotgun_SO.numberIndex]+1);
            
            for (int i = 0; i <shotgun_SO.number[shotgun_SO.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotRight.transform.position, quaternion.identity);
                
                var x = (Vector3)lastDirection + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*shotgun_SO.number[shotgun_SO.numberIndex]/2f), Vector3.forward) * Vector3.right;
                spawnBullet.transform.right = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(spawnBullet.transform.right * velocityRight);
                
                /*switch (i)
                {
                    case 0:
                        var x = lastDirection + new Vector2(lastDirection.x, 1);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(x.normalized * velocityRight);
                        break;
                    case 1:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(lastDirection * velocityRight);
                        break;
                    case 2:
                        var y = lastDirection + new Vector2(lastDirection.x, -1).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(y.normalized * velocityRight);
                        break;
                }*/
            }
        }
        if (lastDirection == Vector2.left)
        {
            velocityLeft = -shotgun_SO.velocity[shotgun_SO.velocityIndex];
            var angle = 360 / (shotgun_SO.number[shotgun_SO.numberIndex]+1);
            
            for (int i = 0; i < shotgun_SO.number[shotgun_SO.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotleft.transform.position, quaternion.identity);
                
                var x = (Vector3)lastDirection + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*shotgun_SO.number[shotgun_SO.numberIndex]/2f), Vector3.forward) * -(Vector3.right);
                spawnBullet.transform.right = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(-spawnBullet.transform.right * velocityLeft);
                /*switch (i)
                {
                    case 0:
                        var x = lastDirection + new Vector2(lastDirection.x, 1);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-x.normalized * velocityLeft);
                        break;
                    case 1:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-lastDirection * velocityLeft);
                        break;
                    case 2:
                        var y = lastDirection + new Vector2(lastDirection.x, -1).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-y.normalized * velocityLeft);
                        break;
                }*/
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
            velocityDown = -shotgun_SO.velocity[shotgun_SO.velocityIndex];
            velocityTop = shotgun_SO.velocity[shotgun_SO.velocityIndex];

            var angle = 360 / (shotgun_SO.number[shotgun_SO.numberIndex]+1);
            
            for (int i = 0; i < shotgun_SO.number[shotgun_SO.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotTop.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.up + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*shotgun_SO.number[shotgun_SO.numberIndex]/2f), Vector3.forward) * (Vector3.up);
                spawnBullet.transform.up = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(spawnBullet.transform.up * velocityTop);
                /*switch (i)
                {
                    case 0:
                        var x = Vector2.up + new Vector2(-1, Vector2.up.y);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(x.normalized * velocityTop);
                        break;
                    case 1:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * velocityTop);
                        break;
                    case 2:
                        var y = Vector2.up + new Vector2(1, Vector2.up.y).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(y.normalized * velocityTop);
                        break;
                }*/
            }
            for (int i = 0; i < shotgun_SO.number[shotgun_SO.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotDown.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.down + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*shotgun_SO.number[shotgun_SO.numberIndex]/2f), Vector3.forward) * -(Vector3.up);
                spawnBullet.transform.up = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(-spawnBullet.transform.up * velocityDown);
                /*switch (i)
                {
                    case 0:
                        var x = Vector2.down + new Vector2(-1, Vector2.down.y);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-x.normalized * velocityDown);
                        break;
                    case 1:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-Vector2.down * velocityDown);
                        break;
                    case 2:
                        var y = Vector2.down + new Vector2(1, Vector2.down.y).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-y.normalized * velocityDown);
                        break;
                }*/
            }
        }
        if (lastDirection == Vector2.right || lastDirection == Vector2.left)
        {
            velocityRight = shotgun_SO.velocity[shotgun_SO.velocityIndex];
            velocityLeft = -shotgun_SO.velocity[shotgun_SO.velocityIndex];
            var angle = 360 / (shotgun_SO.number[shotgun_SO.numberIndex]+1);
            
            for (int i = 0; i < shotgun_SO.number[shotgun_SO.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotRight.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.right+ Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*shotgun_SO.number[shotgun_SO.numberIndex]/2f), Vector3.forward) * (Vector3.right);
                spawnBullet.transform.right = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(spawnBullet.transform.right * velocityRight);
                /*switch (i)
                {
                    case 0:
                        var x = Vector2.right + new Vector2(Vector2.right.x, 1);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(x.normalized * velocityRight);
                        break;
                    case 1:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * velocityRight);
                        break;
                    case 2:
                        var y = Vector2.right + new Vector2(Vector2.right.x, -1).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(y.normalized * velocityRight);
                        break;
                }*/
            }
            
            for (int i = 0; i < shotgun_SO.number[shotgun_SO.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotleft.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.left + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*shotgun_SO.number[shotgun_SO.numberIndex]/2f), Vector3.forward) * -(Vector3.right);
                spawnBullet.transform.right = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(-spawnBullet.transform.right * velocityLeft);
                /*switch (i)
                {
                    case 0:
                        var x = Vector2.left + new Vector2(Vector2.left.x, 1);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-x.normalized * velocityLeft);
                        break;
                    case 1:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-Vector2.left * velocityLeft);
                        break;
                    case 2:
                        var y = Vector2.left + new Vector2(Vector2.left.x, -1).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-y.normalized * velocityLeft);
                        break;
                }*/
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
            velocityDown = -shotgun_SO.velocity[shotgun_SO.velocityIndex];
            velocityTop = shotgun_SO.velocity[shotgun_SO.velocityIndex];
            velocityRight = shotgun_SO.velocity[shotgun_SO.velocityIndex];
            velocityLeft = -shotgun_SO.velocity[shotgun_SO.velocityIndex];
            
            var angle = 360 / (shotgun_SO.number[shotgun_SO.numberIndex]+1);
            for (int i = 0; i < shotgun_SO.number[shotgun_SO.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotTop.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.up + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*shotgun_SO.number[shotgun_SO.numberIndex]/2f), Vector3.forward) * (Vector3.up);
                spawnBullet.transform.up = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(spawnBullet.transform.up * velocityTop);
                /*switch (i)
                {
                    case 0:
                        var x = Vector2.up + new Vector2(-1, Vector2.up.y);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(x.normalized * velocityTop);
                        break;
                    case 1:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * velocityTop);
                        break;
                    case 2:
                        var y = Vector2.up + new Vector2(1, Vector2.up.y).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(y.normalized * velocityTop);
                        break;
                }*/
            }
            for (int i = 0; i < shotgun_SO.number[shotgun_SO.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotDown.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.down + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*shotgun_SO.number[shotgun_SO.numberIndex]/2f), Vector3.forward) * -(Vector3.up);
                spawnBullet.transform.up = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(-spawnBullet.transform.up * velocityDown);
                /*switch (i)
                {
                    case 0:
                        var x = Vector2.down + new Vector2(-1, Vector2.down.y);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-x.normalized * velocityDown);
                        break;
                    case 1:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-Vector2.down * velocityDown);
                        break;
                    case 2:
                        var y = Vector2.down + new Vector2(1, Vector2.down.y).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-y.normalized * velocityDown);
                        break;
                }*/
            }
            
            for (int i = 0; i <shotgun_SO.number[shotgun_SO.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotRight.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.right + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*shotgun_SO.number[shotgun_SO.numberIndex]/2f), Vector3.forward) * (Vector3.right);
                spawnBullet.transform.right = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(spawnBullet.transform.right * velocityRight);
                /*switch (i)
                {
                    case 0:
                        var x = Vector2.right + new Vector2(Vector2.right.x, 1);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(x.normalized * velocityRight);
                        break;
                    case 1:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * velocityRight);
                        break;
                    case 2:
                        var y = Vector2.right + new Vector2(Vector2.right.x, -1).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(y.normalized * velocityRight);
                        break;
                }*/
            }
            
            for (int i = 0; i <shotgun_SO.number[shotgun_SO.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotleft.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.left + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*shotgun_SO.number[shotgun_SO.numberIndex]/2f), Vector3.forward) * -(Vector3.right);
                spawnBullet.transform.right = x;
                spawnBullet.GetComponent<Rigidbody2D>().AddForce(-spawnBullet.transform.right * velocityLeft);
                /*switch (i)
                {
                    case 0:
                        var x = Vector2.left + new Vector2(Vector2.left.x, 1);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-x.normalized * velocityLeft);
                        break;
                    case 1:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-Vector2.left * velocityLeft);
                        break;
                    case 2:
                        var y = Vector2.left + new Vector2(Vector2.left.x, -1).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(-y.normalized * velocityLeft);
                        break;
                }*/
            }
        }
    }
}  
