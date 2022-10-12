using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LifeBox : MonoBehaviour
{
    public GameObject coeur;
    [HideInInspector]public GameObject trait;
    [HideInInspector]public GameObject trait2;

    public LifeBoxSO heartSO;
    public int heartValue;



    private void Update()
    {
        coeur.transform.Rotate (50*Time.deltaTime,0, 0);
        //trait.transform.Rotate (50*Time.deltaTime,0, 0);
        //trait2.transform.Rotate ( 0,50*Time.deltaTime, 0);
        
        heartValue = heartSO.heartValue[XP_Manager.instance.levelPlayer];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LifeManager.instance.current_life += heartValue;
            Destroy(gameObject);
        }
    }
}
