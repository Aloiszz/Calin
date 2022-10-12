using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class VagueManager : MonoBehaviour
{
    public GameObject target;
    public GameObject Rush;
    public GameObject heart;
    public List<int> RushNumber;
    public int rushNumberIndex;
    public List<int> RushNumber2;
    public int rushNumberIndex2;
    
    public List<float> vagueTimer;
    public int vagueTimerIndex;

    public List<int> lifeDrop;
    public int lifeDropIndex;
    public List<float> lifeTimer;
    public int lifeTimerIndex;

    private GameObject newEnnemy;
    private GameObject newLife;
    public bool isSpawn = true;
    private float xBorder;
    private float yBorder;

    public bool isSpawnCoeur = false;
    private float xBorderHeart;
    private float yBorderHeart;
    
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
            for (int i = 1; i < RushNumber[rushNumberIndex]+1; i++)
            {
                xBorder = Random.Range(-30f, 50f);
                yBorder = Random.Range(-30f, 50f);
                newEnnemy = Instantiate(Rush, PlayerController.instance.transform.position + new Vector3(xBorder, yBorder, 0), Quaternion.identity);
                newEnnemy.GetComponent<AIDestinationSetter>().target = target.transform;
                newEnnemy.GetComponent<Rush>().SecureSO();
            }
            
            /*for (int j = 1; j < RushNumber2[rushNumberIndex2]+1; j++)
            {
                xBorder = Random.Range(-30f, 50f);
                yBorder = Random.Range(-30f, 50f);
                newEnnemy = Instantiate(Rush2, PlayerController.instance.transform.position + new Vector3(xBorder, yBorder, 0), Quaternion.identity);
                newEnnemy.GetComponent<AIDestinationSetter>().target = target.transform;
                newEnnemy.GetComponent<Rush>().SecureSO();
            }*/
            isSpawn = false;
            rushNumberIndex++;
        }

        if (isSpawnCoeur)
        {
            for (int k = 0; k < lifeDrop[lifeDropIndex]; k++)
            {
                xBorderHeart = Random.Range(-8f, 8f);
                yBorderHeart = Random.Range(-8f, 8f);
                newLife = Instantiate(heart, PlayerController.instance.transform.position + new Vector3(xBorderHeart, yBorderHeart, 0), quaternion.identity);
                newLife.gameObject.transform.DOScale(new Vector3(1.184821f, 2.023294f, 1), 1f);
            }
            isSpawnCoeur = false;
        }
    }
}
