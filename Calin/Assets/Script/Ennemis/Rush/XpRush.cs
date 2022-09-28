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

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!isColor)
        {
            StartCoroutine(ChangeCouleur());
        }
        RendreJolie();
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
