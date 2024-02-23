using System;
using System.Collections;
using System.Collections.Generic;
using Destructible2D.Examples;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private D2dExplosion _explosionScript;
    private float powerUpPercent;
    private void Awake()
    {
        _explosionScript = GetComponent<D2dExplosion>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(TimerBoom());
        if (col.gameObject.GetComponent<HealthManager>())
        {
            col.gameObject.GetComponent<HealthManager>().BulletCollided(20);
        }
    }
    
    IEnumerator TimerBoom()
    {
        yield return new WaitForSeconds(0.1f);
        if (_explosionScript)
        {
            _explosionScript.enabled = true;
        }
        Destroy(gameObject,0.1f);
    }
}