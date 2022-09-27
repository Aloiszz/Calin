using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShotgunBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private CircleCollider2D coll;

    public static ShotgunBullet instance;
    
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
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();

        Choose();
        //Destroy(gameObject, 1);
    }

    void Choose()
    {
        /*switch (Shotgun.instance.variation)
        {
            case 1:
                Shoot(Shotgun.instance.velocityX, Shotgun.instance.velocityY);
                break;
            case 2:
                Shoot(Shotgun.instance.velocityX, Shotgun.instance.velocityY);
                break;
        }*/
    }
    

    public void Shoot(Vector2 vec, float y, Vector3 angle)
    {
        //rb.velocity = new Vector2(x, y);
        rb.AddForce(vec * y);
        gameObject.transform.DORotate(angle, 0);
    }
  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
