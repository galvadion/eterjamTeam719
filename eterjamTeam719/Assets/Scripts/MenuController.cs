using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void onStartClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void onCreditClick()
    {
        SceneManager.LoadScene("Credits");
    }

    public void onMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void onQuitClick()
    {
        Application.Quit();
    }
}
