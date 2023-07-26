using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var screenPause = Instantiate(Resources.Load<ScreenPause>("Canvas_Pause"));
            ScreenManager.Instance.Push(screenPause);
        }
    }
}
