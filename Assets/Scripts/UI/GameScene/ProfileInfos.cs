using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ProfileInfos : MonoBehaviour
{
    [SerializeField] private Image playerFlag, botFlag;
    [SerializeField] private TextMeshProUGUI playerTmp;
    [SerializeField] private Sprite[] flags;

    private void Start()
    {
        playerFlag.sprite = flags[PlayerPrefs.GetInt("flag")];
        playerTmp.text = PlayerPrefs.GetString("name");
        botFlag.sprite = flags[Random.Range(0,flags.Length)];
    }
}
