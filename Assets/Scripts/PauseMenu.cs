using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void GoToLevelSelector()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("LevelSelector");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Level" + GameManager.level.ToString());
    }

    public void Quit()
    {
        Application.Quit();
    }
}
