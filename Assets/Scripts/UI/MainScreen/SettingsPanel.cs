using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button musicbtn,effectbtn,notificationbtn,vibrationbtn,langbutton;
    [SerializeField] private Sprite on,off;

    public void MusicBtn()
    {
        musicbtn.GetComponent<Button>().onClick.AddListener(() => musicbtn.GetComponent<Image>().sprite = (musicbtn.GetComponent<Image>().sprite == on) ? off : on);
    }
    
    public void EffectBtn()
    {
        effectbtn.GetComponent<Button>().onClick.AddListener(() => effectbtn.GetComponent<Image>().sprite = (effectbtn.GetComponent<Image>().sprite == on) ? off : on);
    }
    
    public void NotificationBtn()
    {
        notificationbtn.GetComponent<Button>().onClick.AddListener(() => notificationbtn.GetComponent<Image>().sprite = (notificationbtn.GetComponent<Image>().sprite == on) ? off : on);
    }
    
    public void VibrationBtn()
    {
        vibrationbtn.GetComponent<Button>().onClick.AddListener(() => vibrationbtn.GetComponent<Image>().sprite = (vibrationbtn.GetComponent<Image>().sprite == on) ? off : on);
    }
    
    public void LangBtn()
    {
        //langbutton.GetComponent<Button>().onClick.AddListener(() => langbutton.GetComponent<Image>().sprite = (langbutton.GetComponent<Image>().sprite == on) ? off : on);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }
    
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
