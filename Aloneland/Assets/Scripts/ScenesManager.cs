using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager
{
   
    public static void ReloadScene()
    {
        SceneManager.LoadScene(1 , LoadSceneMode.Single);
    }

    public static void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
