using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBtn : MonoBehaviour
{
    public void HomeScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
