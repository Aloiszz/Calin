using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushBullet : MonoBehaviour
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
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
            LifeManager.instance.current_life  -= 
                GameObject.FindGameObjectWithTag("Rush").GetComponent<Rush>().damage;;
            
            PlayerController.instance.OnTouched();
            
        }
    }


    public void Destroy()
    {
        Destroy(gameObject);
    }
}
