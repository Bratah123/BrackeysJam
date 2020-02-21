using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Info()
    {
        SceneManager.LoadScene("InfoPage");
    }

    public void BackInfo()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }
    public void TutorialLevel()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
