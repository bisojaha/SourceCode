using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;

    public void Close()
    {
        menu.SetActive(false); 
    }

    public void TheaterScene()
    {
        if (SceneManager.GetActiveScene().name != "01.TheaterScene")
        { SceneManager.LoadScene(1); }
    }

    public void LobbyScene()
    {
        if (SceneManager.GetActiveScene().name != "03.LobbyScene")
        { SceneManager.LoadScene(3); }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
