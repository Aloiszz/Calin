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
        gameObject.transform.Rotate (0,50*Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            DestroyBullet();
            VoileBlanc();
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            
            StartCoroutine(RESHootAgain());
        }
    }

    IEnumerator RESHootAgain()
    {
        _rushObjs2 = GameObject.FindGameObjectsWithTag("Rush");
        foreach (GameObject rush in _rushObjs2)
        {
            rush.GetComponent<Rush>().isShooting = false;
        };
        
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
        foreach (GameObject rush in _rushObjs2)
        {
            rush.GetComponent<Rush>().isShooting = true;
        };
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
