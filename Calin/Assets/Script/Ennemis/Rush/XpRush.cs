using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class XpRush : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    private float time = 0.5f;
    private bool isColor;
    public int xp;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        gameObject.transform.DOMove(PlayerController.instance.transform.position, 0.5f);
        if (!isColor)
        {
            StartCoroutine(ChangeCouleur());
        }
        RendreJolie();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            XP_Manager.instance.current_XP  += xp;; //GameObject.FindGameObjectWithTag("Rush").GetComponent<Rush>().
            gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
            Destroy(gameObject, 0.3f);
        }
    }

    void RendreJolie()
    {
        gameObject.transform.DORotate(new Vector3(0, 0, -900), 20);
    }
    
    IEnumerator ChangeCouleur()
    {
        isColor = true;
        SpriteRenderer.DOColor(Color.yellow, time);
        yield return new WaitForSeconds(time);
        SpriteRenderer.DOColor(Color.red, time);
        yield return new WaitForSeconds(time);
        SpriteRenderer.DOColor(Color.green, time);
        yield return new WaitForSeconds(time);
        SpriteRenderer.DOColor(Color.white, time);
        yield return new WaitForSeconds(time);
        SpriteRenderer.DOColor(Color.yellow, time);
        yield return new WaitForSeconds(time);
        SpriteRenderer.DOColor(Color.cyan, time);
        yield return new WaitForSeconds(time);
        isColor = false;
    }
}
