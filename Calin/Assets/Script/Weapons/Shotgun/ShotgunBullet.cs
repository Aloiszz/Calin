using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D coll;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        rb.velocity = new Vector2(Shotgun.instance.shotgun_SO.velocity[Shotgun.instance.shotgun_SO.numberIndex], 0);
    }
  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
