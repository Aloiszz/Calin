using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShotgunBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private CircleCollider2D coll;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        /*StartCoroutine(Wait());*/
    }

    private void Update()
    {
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Rush"))
        {
            Rush onTouched = col.GetComponent<Rush>();
            onTouched.OnTouched();
            Destroy(gameObject);
        }
    }

    /*IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.56f);
        gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
    }*/
}
