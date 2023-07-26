using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenPause : MonoBehaviour,IScreen
{
    public Button[] _buttons;

    private void Awake()
    {
        ActivateButtons(false);
    }

    public void BTN_Options()
    {
        ScreenManager.Instance.Push("Canvas_Options");
    }
    
    public void BTN_Back()
    {
        ScreenManager.Instance.Pop();
    }

    void ActivateButtons(bool enable)
    {
        foreach (var button in _buttons)
        {
            button.interactable = enable;
        }
    }

    public void Activate()
    {
        ActivateButtons(true);
    }

    public void Deactivate()
    {
        ActivateButtons(false);
    }

    public void Free()
    {
        Destroy(gameObject);
    }
}
