using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameController : MonoBehaviour
{
    [Header("Levels To Load")]
    public string nameLevel;

    void start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(nameLevel);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
