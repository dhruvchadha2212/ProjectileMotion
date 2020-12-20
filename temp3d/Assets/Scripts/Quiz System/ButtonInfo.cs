using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

/// <summary>
/// Class to sit on UI buttons, and give method to fetch button name enum. 
/// Implemented because we can't pass enums to methods in inspector.
/// </summary>
public class ButtonInfo : MonoBehaviour
{
    [SerializeField] private GameButton gameButton;

    public GameButton GetGameButton()
    {
        return gameButton;
    }
}
