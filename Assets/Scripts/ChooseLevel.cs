using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour {

    public void GoToLevel()
    {
        Application.LoadLevel(transform.parent.gameObject.name);

        char[] levelName = transform.parent.gameObject.name.ToCharArray();
        GameManager.level = (int)levelName[levelName.Length];
    }

    public void GoBack()
    {
        Application.LoadLevel("Menu");
    }
}
