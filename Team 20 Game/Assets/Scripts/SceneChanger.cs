using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject credits;
    public GameObject mainScreen;
    public GameObject bears;

    private void Start()
    {
        if (credits != null)
        {
            credits.SetActive(false);
        }
    }
    private void Update()
    {
        if (GameManager.gameWin)
        {
            SceneManager.LoadScene("EndScreen");
            GameManager.gameWin = false;
        }
    }

    public void Game()
    {
        SceneManager.LoadScene("BaseLevel");
    }
    public void Credits()
    {
        credits.SetActive(true);
        mainScreen.SetActive(false);
        bears.SetActive(false);
    }
    public void BackButton()
    {
        mainScreen.SetActive(true);
        credits.SetActive(false);
        bears.SetActive(true);
    }
}
