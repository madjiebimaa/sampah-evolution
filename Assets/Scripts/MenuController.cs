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

    public void SettingGame()
    {
        Debug.Log("SETTINGS");
        SceneManager.LoadScene(2);
    }
}
