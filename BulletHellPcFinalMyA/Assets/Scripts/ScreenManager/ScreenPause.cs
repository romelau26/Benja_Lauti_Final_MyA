using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenPause : MonoBehaviour,IScreen
{
    public Button[] _buttons;
    public GameObject control;
    public GameObject PauseMg;

    private void Awake()
    {
        ActivateButtons(false);
    }

    public void ActImagControls()
    {
        control.SetActive(true);
        PauseMg.SetActive(false);
    }

    public void DesImagControls()
    {
        control.SetActive(false);
        PauseMg.SetActive(true);
    }

    public void BTN_Back()
    {
        PauseMenu.instance.CanvPause--;
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
