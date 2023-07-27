using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public int CanvPause = 0;//para no tener un spam de canvas
    public Transform MgGame;
    static public PauseMenu instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ScreenManager.Instance.Push(new ScreenGameObjects(MgGame));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && CanvPause==0)
        {
            CanvPause++;
            var screenPause = Instantiate(Resources.Load<ScreenPause>("Canvas_Pause"));
            ScreenManager.Instance.Push(screenPause);
        }
    }
}
