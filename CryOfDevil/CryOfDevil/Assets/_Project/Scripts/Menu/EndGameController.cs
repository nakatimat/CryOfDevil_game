using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    void start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    [Header("Levels To Load")]
    public string retry_;
    public string backToMenu;

    public void RetryButton()
    {
        SceneManager.LoadScene(retry_);
    }

    public void backToMenuButton()
    {
        SceneManager.LoadScene(backToMenu);
    }
}
