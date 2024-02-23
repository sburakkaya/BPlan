using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSettingsPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private Button[] flagBtns;
    [SerializeField] private GameObject[] flagBgs;
    [SerializeField] private TextMeshProUGUI mainMenuPlayerName,matchMakingPlayerName;
    [SerializeField] private Image matchmakingPlayerFlagImg;

    private void Start()
    {
        playerNameInput.onValueChanged.AddListener(PlayNameChanged);
        for (int i = 0; i < flagBtns.Length; i++)
        {
            int index = i;
            flagBtns[i].onClick.AddListener((() => PlayerFlagChange(index)));
        }

        if (PlayerPrefs.HasKey("name"))
        {
            playerNameInput.text = PlayerPrefs.GetString("name");
            mainMenuPlayerName.text = PlayerPrefs.GetString("name");
            matchMakingPlayerName.text = PlayerPrefs.GetString("name");
        }
        else
        {
            PlayerPrefs.SetString("name","Player");
            playerNameInput.text = PlayerPrefs.GetString("name");
        }
        if (PlayerPrefs.HasKey("flag"))
        {
            for (int i = 0; i < flagBgs.Length; i++)
            {
                flagBgs[i].GetComponent<Image>().enabled = false;
            }
            flagBgs[PlayerPrefs.GetInt("flag")].GetComponent<Image>().enabled = true;
            matchmakingPlayerFlagImg.sprite = flagBtns[PlayerPrefs.GetInt("flag")].GetComponent<Image>().sprite;
        }
        else
        {
            PlayerPrefs.SetString("flag","0");
            for (int i = 0; i < flagBgs.Length; i++)
            {
                flagBgs[i].GetComponent<Image>().enabled = false;
            }
            flagBgs[PlayerPrefs.GetInt("flag")].GetComponent<Image>().enabled = true;
        }
    }

    void PlayNameChanged(string nameInp)
    {
        PlayerPrefs.SetString("name",nameInp);
        mainMenuPlayerName.text = PlayerPrefs.GetString("name");
        matchMakingPlayerName.text = PlayerPrefs.GetString("name");
    }

    void PlayerFlagChange(int flagInt)
    {
        PlayerPrefs.SetInt("flag",flagInt);
        for (int i = 0; i < flagBgs.Length; i++)
        {
            flagBgs[i].GetComponent<Image>().enabled = false;
        }
        flagBgs[flagInt].GetComponent<Image>().enabled = true;
        matchmakingPlayerFlagImg.sprite = flagBtns[PlayerPrefs.GetInt("flag")].GetComponent<Image>().sprite;
    }
}
