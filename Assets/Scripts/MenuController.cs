using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("PLAY");

        SceneManager.LoadScene(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");

        Application.Quit();
    }

    public void HowToPlay()
    {
        Debug.Log("How To Play");
        SceneManager.LoadScene(3);
    }

    public void nextStory()
    {
        SceneManager.LoadScene(2);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
