using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBtnController : MonoBehaviour
{
    [SerializeField] private MatchmakingPanel matchmakingPanel;

    public void MatchStarterBtn()
    {
        matchmakingPanel.gameObject.SetActive(true);
        matchmakingPanel.MatchStarter();
    }
}
