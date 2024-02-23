using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image _healthImg;
    private float healthfloat = 100;
    private bool isDead { get; set; }
    
    public void BulletCollided(float dmg)
    {
        healthfloat -= dmg;
        _healthImg.fillAmount = healthfloat / 100f;
        CheckHealth();
    }

    private void LateUpdate()
    {
        if (transform.position.y < -6 && !isDead)
        {
            isDead = true;
            healthfloat = 0;
            CheckHealth();
        }
    }

    void CheckHealth()
    {
        if (healthfloat < 3)
        {
            if (tag == "Player")
            {
                GameManager.Instance.LoseGame();
            }
            else
            {
                GameManager.Instance.WinGame();
            }
        }
    }
}
