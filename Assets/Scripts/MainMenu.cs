using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool on = false;

    public void Start()
    {
        if (on == false)
        {
            FindObjectOfType<AudioController>().Play("Background Music");
            on = true;
        }

    }
    // Returns to main menu from one of the sub-menus
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    // Loads the game
    public void PlayGame()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
        FindObjectOfType<AudioController>().Play("startup");
    }

    // Loads the credit scene
    public void CreditsButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    // Quit the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
