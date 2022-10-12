using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour
{

    public List<GameObject> rushBullet;
    private GameObject[] _rushObjs;
    private GameObject[] _rushObjs2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            DestroyBullet();
            VoileBlanc();
            Destroy(gameObject);
            _rushObjs2 = GameObject.FindGameObjectsWithTag("Rush");
            foreach (GameObject rush in _rushObjs2)
            {
                rush.GetComponent<Rush>().isShooting = false;
            };
        }
    }

    void DestroyBullet()
    {
        _rushObjs = GameObject.FindGameObjectsWithTag("RushBullet");
        foreach (GameObject rush in _rushObjs)
        {
            rush.GetComponent<RushBullet>().Destroy();
        }
    }

    void VoileBlanc()
    {
        GameManager.instance.isVoileBlanc = true;
    }
}
