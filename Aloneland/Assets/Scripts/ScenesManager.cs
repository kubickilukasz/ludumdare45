﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager
{
   
    public static void ReloadScene()
    {
        SceneManager.LoadScene(0 , LoadSceneMode.Single);
    }
}
