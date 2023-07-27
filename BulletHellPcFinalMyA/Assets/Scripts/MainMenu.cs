using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject control;
    public GameObject[] MgGame;
    public void MoveScenes(string NameScene) { SceneManager.LoadScene(NameScene); }
    public void QuitGame() { Application.Quit(); }
    public void ActImagControls()
    {
        control.SetActive(true);
        for (int i = 0; i < MgGame.Length; i++)
        {
            MgGame[i].SetActive(false);
        } 
    }

    public void DesImagControls()
    {
        control.SetActive(false);
        for (int i = 0; i < MgGame.Length; i++)
        {
            MgGame[i].SetActive(true);
        }
    }
}
