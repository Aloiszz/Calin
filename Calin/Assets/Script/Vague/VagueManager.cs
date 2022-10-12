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
    
    public GameObject heart;
    
    [Header("RUSH")]
    public GameObject Rush;
    public List<int> RushNumber;
    public int rushNumberIndex;
    public List<float> vagueTimer;
    public int vagueTimerIndex;
    private GameObject newEnnemy;
    private float xBorder;
    private float yBorder;
    public bool isSpawn = true;
    
    [Header("RUSH Jaune ")]
    public GameObject Rush2;
    public List<int> RushNumber2;
    public int rushNumberIndex2;
    public List<float> vagueTimer2;
    public int vagueTimerIndex2;
    private float xBorder2;
    private float yBorder2;
    public bool isSpawn2 = true;
    
    [Header("RUSH VERT ")]
    public GameObject Rush3;
    public List<int> RushNumber3;
    public int rushNumberIndex3;
    public List<float> vagueTimer3;
    public int vagueTimerIndex3;
    private float xBorder3;
    private float yBorder3;
    public bool isSpawn3= true;
    
    [Header("RUSH NOIR ")]
    public GameObject Rush4;
    public List<int> RushNumber4;
    public int rushNumberIndex4;
    public List<float> vagueTimer4;
    public int vagueTimerIndex4;
    private float xBorder4;
    private float yBorder4;
    public bool isSpawn4= true;
    
    
    [Header("Life")]
    public List<int> lifeDrop;
    public int lifeDropIndex;
    public List<float> lifeTimer;
    public int lifeTimerIndex;
    private GameObject newLife;
    public bool isSpawnCoeur = false;
    private float xBorderHeart;
    private float yBorderHeart;

    [Header("NUKE")]
    public GameObject NUKE;
    private GameObject newNUKE;
    public bool isSpawnNUKE = false;
    private float xBorderNUKE;
    private float yBorderNUKE;
    
    
    public List<int> NUKEDrop;
    public int NUKEDropIndex;
    public List<float> NUKETimer;
    public int NUKETimerIndex;
    
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
            isSpawn = false;
            rushNumberIndex++;
        }

        if (isSpawn2)
        {
            for (int j = 1; j < RushNumber2[rushNumberIndex2]+1; j++)
            {
                xBorder2 = Random.Range(-30f, 50f);
                yBorder2 = Random.Range(-30f, 50f);
                newEnnemy = Instantiate(Rush2, PlayerController.instance.transform.position + new Vector3(xBorder2, yBorder2, 0), Quaternion.identity);
                newEnnemy.GetComponent<AIDestinationSetter>().target = target.transform;
                newEnnemy.GetComponent<Rush>().SecureSO();
            }
            isSpawn2 = false;
            rushNumberIndex2++;
        }
        
        if (isSpawn3)
        {
            for (int p = 1; p < RushNumber2[rushNumberIndex2]+1; p++)
            {
                xBorder3= Random.Range(-30f, 50f);
                yBorder3 = Random.Range(-30f, 50f);
                newEnnemy = Instantiate(Rush3, PlayerController.instance.transform.position + new Vector3(xBorder3, yBorder3, 0), Quaternion.identity);
                newEnnemy.GetComponent<AIDestinationSetter>().target = target.transform;
                newEnnemy.GetComponent<Rush>().SecureSO();
            }
            isSpawn3 = false;
            rushNumberIndex3++;
        }
        
        if (isSpawn4)
        {
            for (int t = 1; t < RushNumber2[rushNumberIndex2]+1; t++)
            {
                xBorder4= Random.Range(-30f, 50f);
                yBorder4 = Random.Range(-30f, 50f);
                newEnnemy = Instantiate(Rush4, PlayerController.instance.transform.position + new Vector3(xBorder4, yBorder4, 0), Quaternion.identity);
                newEnnemy.GetComponent<AIDestinationSetter>().target = target.transform;
                newEnnemy.GetComponent<Rush>().SecureSO();
            }
            isSpawn4 = false;
            rushNumberIndex4++;
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
        
        if (isSpawnNUKE)
        {
            for (int p = 0; p < NUKEDrop[NUKEDropIndex]; p++)
            {
                xBorderNUKE = Random.Range(-8f, 8f);
                yBorderNUKE = Random.Range(-8f, 8f);
                newNUKE = Instantiate(NUKE, PlayerController.instance.transform.position + new Vector3(xBorderNUKE, yBorderNUKE, 0), quaternion.identity);
                newNUKE.gameObject.transform.DOScale(new Vector3(0.3985f, 0.3985f, 0.3985f), 1f);
            }
            isSpawnNUKE = false;
        }
    }
}
