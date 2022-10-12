using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    public Rigidbody2D rb;
    private CircleCollider2D coll;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
    }


    private void Update()
    {
        Destroy(gameObject, 2);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       if (col.CompareTag("RushBullet"))
       { 
           col.GetComponent<RushBullet>().Destroy();
       }
    }
}
