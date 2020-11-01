using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class ButtonInfo : MonoBehaviour
{
    [SerializeField] private GameButton button;

    private void Start()
    {
        UIManager.InsertKeyValueToButtonMap(button, GetComponent<LeanButton>());
    }

    public GameButton GetGameButton()
    {
        return button;
    }
}
