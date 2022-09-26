using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public SO_Shotgun shotgun_SO;
    
    public GameObject shotgunBullet;
    public GameObject shotTop;
    public GameObject shotDown;
    public GameObject shotRight;
    public GameObject shotleft;
    

    public static Shotgun instance;

    private Vector2 lastDirection;


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

    private void Update()
    {
        lastDirection = PlayerController.instance.lastMovement[^1];
        //Invoke(nameof(Shoot),shotgun_SO.cadency[shotgun_SO.cadencyIndex]);
        Shoot();
    }

    void Shoot()
    {
        if (lastDirection == Vector2.up)
        {
            Debug.Log("Hello");
            Instantiate(shotgunBullet, shotTop.transform.position, quaternion.identity);
        }
        /*if (lastDirection == Vector2.down)
        {
            
        }
        if (lastDirection == Vector2.right)
        {
            
        }
        if (lastDirection == Vector2.left)
        {
            
        }*/
    }
}  
