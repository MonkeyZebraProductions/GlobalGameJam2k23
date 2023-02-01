using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public string zen;
    public string normal;
    public string hard;
    public string MainMenu;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSceneZen()
    {
        SceneManager.LoadScene(zen);
    }

    public void LoadSceneNormal()
    {
        SceneManager.LoadScene(normal);
    }

    public void LoadSceneHard()
    {
        SceneManager.LoadScene(hard);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }

}
