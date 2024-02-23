using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    { 
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(GameManager).Name;
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    [SerializeField] private GameObject winPanel,losePanel;
    
    private PlayerController player;
    private BotController bot;
    private int round = 1;
    private bool isPlayerTurn = false;
    private bool isGameEnd = false;
    private float timer = 0f;
    private float turnTime = 20f;
    
    public float RTimer {get { return timer; }}
    public int Round { get { return round; } }
    public bool IsPlayerTurn { get { return isPlayerTurn; } }

    public event Action<int> OnRoundChanged;
    public event Action<bool> OnTurnChanged;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        bot = FindObjectOfType<BotController>();
        StartCoroutine(StartRound());
    }

    private IEnumerator StartRound()
    {
        while (!isGameEnd)
        {
            timer = turnTime;
            
            isPlayerTurn = !isPlayerTurn;
            if (!isPlayerTurn)
            {
                bot.TakeTurn();
            }
            round++;
            OnRoundChanged?.Invoke(round);
            OnTurnChanged?.Invoke(isPlayerTurn);
            
            while (timer > 0f)
            {
                timer -= Time.deltaTime;
                yield return null;
            }

        }
    }
    
    public void EndRound()
    {
        StopCoroutine("StartRound");
        StartCoroutine("StartRound");
    }

    void EndGame()
    {
        isGameEnd = true;
    }
    
    public void WinGame()
    {
        winPanel.SetActive(true);
        EndGame();
    }
    
    public void LoseGame()
    {
        losePanel.SetActive(true);
        EndGame();
    }
}