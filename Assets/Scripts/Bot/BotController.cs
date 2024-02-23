using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BotController : MonoBehaviour
{
    [SerializeField] private Transform bot;
    [SerializeField] private Transform projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float fireRate = 1f; 
    [SerializeField] private float launchForce = 1.5f;
    [SerializeField] private float trajectoryTimeStep = 0.05f;
    [SerializeField] private int trajectoryStepCount = 15;
    
    private Transform playerTransform;
    private Vector2 velocity, startMousePos, currentMousePos;
    private Rigidbody2D rb;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = bot.GetComponent<Rigidbody2D>();
    }

    public void TakeTurn()
    {
        StartCoroutine(MoveRightForDuration());
        Invoke("FireProjectile",2);
    }
    
    private IEnumerator MoveRightForDuration()
    {
        yield return new WaitForSeconds(1);
        Vector2 originalVelocity = rb.velocity;

        rb.velocity = new Vector2(Random.Range(-4,4), 0f);

        yield return new WaitForSeconds(3);

        rb.velocity = originalVelocity;
    }

    private void Update()
    {
        velocity = (playerTransform.transform.position - transform.position);
        RotateLauncher();
    }


    void FireProjectile()
    {
        Transform pr = Instantiate(projectilePrefab, spawnPoint.position, quaternion.identity);
        Vector2 vel = new Vector2(velocity.x,2);
        pr.GetComponent<Rigidbody2D>().velocity = vel;
        GameManager.Instance.EndRound();
    }

    void RotateLauncher()
    {
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        angle = angle - 30;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }
    
}
