using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject creditSheet;

    private void Start()
    {
        if (creditSheet != null)
        {
            creditSheet.SetActive(false);
        }
    }
    private void Update()
    {
        if (GameManager.gameWin)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    public void Game()
    {
        SceneManager.LoadScene("BaseLevel");
    }
    public void Credits()
    {
        creditSheet.SetActive(true);
    }
}
