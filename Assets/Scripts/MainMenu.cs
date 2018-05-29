using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public void ChooseLevel()
    {
        Application.LoadLevel("LevelSelector");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
