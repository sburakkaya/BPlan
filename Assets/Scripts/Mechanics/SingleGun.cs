using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private bool hitted = false;
    private float powerUpPercent;

    private void Update()
    {
        float currentRotation = gameObject.transform.rotation.eulerAngles.z;
        float targetRotation = -60;
        gameObject.transform.rotation = Quaternion.Lerp(Quaternion.Euler(0,0,currentRotation), Quaternion.Euler(0,0,targetRotation), Time.deltaTime);

    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Hitted();
    }
    
    private void Hitted()
    {
        if (!hitted)
        {
            hitted = true;
            GameObject newbullet = Instantiate(bullet,this.transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}