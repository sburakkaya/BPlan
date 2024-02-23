using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomMenuController : MonoBehaviour
{
    [SerializeField] private Button profileBtn, upgradeBtn, gunsbtn, characterBtn, bankBtn;
    [SerializeField] private GameObject profilePanel;

    private void OnEnable()
    {
        profileBtn.onClick.AddListener(ClosePanels);
        upgradeBtn.onClick.AddListener(ClosePanels);
        gunsbtn.onClick.AddListener(ClosePanels);
        characterBtn.onClick.AddListener(ClosePanels);
        bankBtn.onClick.AddListener(ClosePanels);
        
        profileBtn.onClick.AddListener(ProfilePanelOpen);
    }

    void ClosePanels()
    {
        profilePanel.SetActive(false);
    }

    void ProfilePanelOpen()
    {
        profilePanel.SetActive(true);
    }
}
