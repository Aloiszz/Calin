using System;
using System.Collections;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;


public class Shotgun : MonoBehaviour
{
    public SO_Shotgun shotgun_SO;
    
    [HideInInspector]public GameObject shotgunBullet;
    [HideInInspector]public Transform shotTop;
    [HideInInspector]public Transform shotDown;
    [HideInInspector]public Transform shotRight;
    [HideInInspector]public Transform shotleft;

    
    [HideInInspector]public float velocityTop;
    [HideInInspector]public float velocityDown;
    [HideInInspector]public float velocityRight;
    [HideInInspector]public float velocityLeft;

    public static Shotgun instance;
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
        number = shotgun_SO.number[numberIndex];
        //numberIndex = shotgun_SO.numberIndex;
        velocity = shotgun_SO.velocity[velocityIndex];
        //velocityIndex = shotgun_SO.velocityIndex;
        cadency = shotgun_SO.cadency[cadencyIndex];
        //cadencyIndex = shotgun_SO.cadencyIndex;
        axeShoot = shotgun_SO.axeShoot[axeShootIndex];
        //axeShootIndex = shotgun_SO.axeShootIndex;
        
        bulletDamage = shotgun_SO.bulletDamage[levelPlayer];
    }

    private void Start()
    {
        SecureSO();
        shotTop = transform.Find("ShotGun/ShotgunPointTop");
        shotDown = transform.Find("ShotGun/ShotgunPointDown");
        shotleft = transform.Find("ShotGun/ShotgunPointLeft");
        shotRight = transform.Find("ShotGun/ShotgunPointRight");
        
        //InvokeRepeating(nameof(Choose),0, cadency);
        PlayerController.instance.lastMovement.Add(Vector2.zero);
    }

    private void Update()
    {
        lastDirection = PlayerController.instance.lastMovement[^1];
        if (canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        Choose();
        yield return new WaitForSeconds(cadency);
        canShoot = true;
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
                var spawnBullet = Instantiate(shotgunBullet, shotTop.transform.position, quaternion.identity);

                var x = (Vector3)lastDirection + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle* number/2f), Vector3.forward) * Vector3.up;
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
            velocityDown = -velocity;
            var angle = 360 / number+1;
            
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotDown.transform.position, quaternion.identity);
                
                var x = (Vector3)lastDirection + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * -(Vector3.up);
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
            velocityRight = velocity;
            var angle = 360 / (number+1);
            
            for (int i = 0; i <number; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotRight.transform.position, quaternion.identity);
                
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
                var spawnBullet = Instantiate(shotgunBullet, shotleft.transform.position, quaternion.identity);
                
                var x = (Vector3)lastDirection + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * -(Vector3.right);
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
            velocityDown = -velocity;
            velocityTop = velocity;

            var angle = 360 / (number+1);
            
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotTop.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.up + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * (Vector3.up);
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
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotDown.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.down + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * -(Vector3.up);
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
            velocityRight = velocity;
            velocityLeft = -velocity;
            var angle = 360 / (number+1);
            
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotRight.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.right+ Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * (Vector3.right);
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
            
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotleft.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.left + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * -(Vector3.right);
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
            velocityDown = -velocity;
            velocityTop = velocity;
            velocityRight = velocity;
            velocityLeft = -velocity;
            
            var angle = 360 / (number+1);
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotTop.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.up + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * (Vector3.up);
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
            for (int i = 0; i < number; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotDown.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.down + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * -(Vector3.up);
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
            
            for (int i = 0; i <number; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotRight.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.right + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * (Vector3.right);
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
            
            for (int i = 0; i <number; i++)
            {
                var spawnBullet = Instantiate(shotgunBullet, shotleft.transform.position, quaternion.identity);
                
                var x = (Vector3)Vector2.left + Quaternion.AngleAxis(angle/2f+(angle * i)-(angle*number/2f), Vector3.forward) * -(Vector3.right);
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
