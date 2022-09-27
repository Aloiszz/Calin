using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public SO_Laser laser_so; 
    
    [HideInInspector]public GameObject lasershot;
    [HideInInspector]public GameObject shotTop;
    [HideInInspector]public GameObject shotDown;
    [HideInInspector]public GameObject shotRight;
    [HideInInspector]public GameObject shotleft;

    
    [HideInInspector]public float velocityTop;
    [HideInInspector]public float velocityDown;
    [HideInInspector]public float velocityRight;
    [HideInInspector]public float velocityLeft;
    

    public static Laser instance;

    public Vector2 lastDirection;

    [Header("Variation Axe de tir")]
    public int variation;
    
    
    private void Start()
    {
        InvokeRepeating(nameof(Choose),0, laser_so.cadency[laser_so.cadencyIndex]);
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
            velocityTop = laser_so.velocity[laser_so.velocityIndex];
            for (int i = 0; i <= laser_so.number[laser_so.numberIndex]; i++)
            {
                var spawnBullet = Instantiate(lasershot, shotTop.transform.position, Quaternion.identity);
                switch (i)
                {
                    case 3:
                        var x = lastDirection + new Vector2(-1, lastDirection.y);
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(x.normalized * velocityTop);
                        break;
                    case 1:
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(lastDirection * velocityTop);
                        break;
                    case 2:
                        var y = lastDirection + new Vector2(1, lastDirection.y).normalized;
                        spawnBullet.GetComponent<Rigidbody2D>().AddForce(y.normalized * velocityTop);
                        break;
                }
            }
        }
        if (lastDirection == Vector2.down)
        {
            velocityDown = -laser_so.velocity[laser_so.velocityIndex];
            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(lasershot, shotDown.transform.position, quaternion.identity);
                switch (i)
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
                }
            }
        }
        if (lastDirection == Vector2.right)
        {
            velocityRight = laser_so.velocity[laser_so.velocityIndex];
            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(lasershot, shotRight.transform.position, quaternion.identity);
                switch (i)
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
                }
            }
        }
        if (lastDirection == Vector2.left)
        {
            velocityLeft = -laser_so.velocity[laser_so.velocityIndex];
            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(lasershot, shotleft.transform.position, quaternion.identity);
                switch (i)
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
                }
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
            velocityDown = -laser_so.velocity[laser_so.velocityIndex];
            velocityTop = laser_so.velocity[laser_so.velocityIndex];
            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(lasershot, shotDown.transform.position, quaternion.identity);
                switch (i)
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
                }
            }
            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(lasershot, shotDown.transform.position, quaternion.identity);
                switch (i)
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
                }
            }
        }
        if (lastDirection == Vector2.right || lastDirection == Vector2.left)
        {
            velocityRight = laser_so.velocity[laser_so.velocityIndex];
            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(lasershot, shotRight.transform.position, quaternion.identity);
                switch (i)
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
                }
            }
            velocityLeft = -laser_so.velocity[laser_so.velocityIndex];
            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(lasershot, shotleft.transform.position, quaternion.identity);
                switch (i)
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
                }
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
            velocityDown = -laser_so.velocity[laser_so.velocityIndex];
            velocityTop = laser_so.velocity[laser_so.velocityIndex];
            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(lasershot, shotTop.transform.position, quaternion.identity);
                switch (i)
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
                }
            }
            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(lasershot, shotDown.transform.position, quaternion.identity);
                switch (i)
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
                }
            }
            velocityRight = laser_so.velocity[laser_so.velocityIndex];
            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(lasershot, shotDown.transform.position, quaternion.identity);
                switch (i)
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
                }
            }
            velocityLeft = -laser_so.velocity[laser_so.velocityIndex];
            for (int i = 0; i <= 2; i++)
            {
                var spawnBullet = Instantiate(lasershot, shotDown.transform.position, quaternion.identity);
                switch (i)
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
                }
            }
        }
    }
}
