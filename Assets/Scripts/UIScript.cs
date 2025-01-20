using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Console.WriteLine("Game is quitting");
    }
}
