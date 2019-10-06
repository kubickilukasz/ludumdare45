using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        ScenesManager.ReloadScene();
    }

    public void Quit()
    {
        ScenesManager.Quit();
    }

}
