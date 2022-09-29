using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class VagueManager : MonoBehaviour
{
    public GameObject target;
    public GameObject Rush;
    public int RushNumber;
    public float vagueTimer;

    private GameObject newEnnemy;
    public bool isSpawn = true;
    private float xBorder;
    private float yBorder;
    
    public static VagueManager instance;
    
    private void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(gameObject);
        } 
        else 
        { 
            instance = this; 
        }
    }
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawn)
        {
            for (int i = 1; i < RushNumber+1; i++)
            {
                xBorder = Random.Range(-20f, 20f);
                yBorder = Random.Range(-20f, 20f);
                newEnnemy = Instantiate(Rush, PlayerController.instance.transform.position + new Vector3(xBorder, yBorder, 0), Quaternion.identity);
                newEnnemy.GetComponent<AIDestinationSetter>().target = target.transform;
                newEnnemy.GetComponent<Rush>().SecureSO();
            }
            isSpawn = false;
        }
    }
}
