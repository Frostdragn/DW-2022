using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Game()
    {
        SceneManager.LoadScene("BaseLevel");
    }

    public void Menu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
