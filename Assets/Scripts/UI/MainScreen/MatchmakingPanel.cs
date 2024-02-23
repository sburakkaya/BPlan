using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MatchmakingPanel : MonoBehaviour
{
    [SerializeField] private Sprite[] flags;
    [SerializeField] private Image botFlag;
    [SerializeField] private TextMeshProUGUI countdownTmp;
    
    public void MatchStarter()
    {
        StartCoroutine(MathcMakingCoroutine());
    }

    IEnumerator MathcMakingCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        botFlag.sprite = flags[Random.Range(0, flags.Length)];
        yield return new WaitForSeconds(0.5f);
        botFlag.sprite = flags[Random.Range(0, flags.Length)];
        countdownTmp.text = "4 sec..";
        yield return new WaitForSeconds(0.5f);
        botFlag.sprite = flags[Random.Range(0, flags.Length)];
        yield return new WaitForSeconds(0.5f);
        botFlag.sprite = flags[Random.Range(0, flags.Length)];
        countdownTmp.text = "3 sec..";
        yield return new WaitForSeconds(0.5f);
        botFlag.sprite = flags[Random.Range(0, flags.Length)];
        yield return new WaitForSeconds(0.5f);
        botFlag.sprite = flags[Random.Range(0, flags.Length)];
        countdownTmp.text = "2 sec..";
        yield return new WaitForSeconds(0.5f);
        botFlag.sprite = flags[Random.Range(0, flags.Length)];
        yield return new WaitForSeconds(0.5f);
        botFlag.sprite = flags[Random.Range(0, flags.Length)];
        countdownTmp.text = "1 sec..";
        yield return new WaitForSeconds(0.5f);
        botFlag.sprite = flags[Random.Range(0, flags.Length)];
        yield return new WaitForSeconds(0.5f);
        botFlag.sprite = flags[Random.Range(0, flags.Length)];
        countdownTmp.text = "0 sec..";
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameScene");

    }
}
