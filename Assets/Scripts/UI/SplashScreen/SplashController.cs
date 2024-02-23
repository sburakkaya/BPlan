using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpLoading;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.4f);
        tmpLoading.text = "Loading.";
        yield return new WaitForSeconds(0.4f);
        tmpLoading.text = "Loading..";
        yield return new WaitForSeconds(0.4f);
        tmpLoading.text = "Loading...";
        yield return new WaitForSeconds(0.4f);
        tmpLoading.text = "Loading.";
        yield return new WaitForSeconds(0.4f);
        tmpLoading.text = "Loading..";
        yield return new WaitForSeconds(0.4f);
        tmpLoading.text = "Loading...";
        yield return new WaitForSeconds(0.4f);
        tmpLoading.text = "Loading.";
        yield return new WaitForSeconds(0.4f);
        tmpLoading.text = "Loading..";
        yield return new WaitForSeconds(0.4f);
        tmpLoading.text = "Loading...";
        yield return new WaitForSeconds(0.4f);
        tmpLoading.text = "Loading.";
        yield return new WaitForSeconds(0.4f);
        tmpLoading.text = "Loading..";
        yield return new WaitForSeconds(0.4f);
        tmpLoading.text = "Loading...";
        SceneManager.LoadScene("MainScene");
    }
}
