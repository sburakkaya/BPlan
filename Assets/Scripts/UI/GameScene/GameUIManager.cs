using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI playerTurnText;
    public TextMeshProUGUI timeLeftPlayer;
    public TextMeshProUGUI timeLeftBot;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.OnRoundChanged += UpdateRoundText;
        gameManager.OnTurnChanged += UpdatePlayerTurnText;

        UpdateRoundText(gameManager.Round);
        UpdatePlayerTurnText(gameManager.IsPlayerTurn);
    }

    private void UpdateRoundText(int round)
    {
        roundText.text = round.ToString();
    }

    private void UpdatePlayerTurnText(bool isPlayerTurn)
    {
        playerTurnText.text = isPlayerTurn ? "Player's Turn" : "Bot's Turn";
        if (isPlayerTurn)
            timeLeftBot.text = "20";
        else
            timeLeftPlayer.text = "20";
    }

    private void Update()
    {
        UpdateTimeLeftText();
    }

    private void UpdateTimeLeftText()
    {
        if (gameManager.IsPlayerTurn)
        {
            timeLeftPlayer.text = Mathf.RoundToInt(GameManager.Instance.RTimer).ToString();
        }
        else
        {
            timeLeftBot.text = Mathf.RoundToInt(GameManager.Instance.RTimer).ToString();
        }
    }

    private void OnDestroy()
    {
        if (gameManager != null)
        {
            gameManager.OnRoundChanged -= UpdateRoundText;
            gameManager.OnTurnChanged -= UpdatePlayerTurnText;
        }
    }
}