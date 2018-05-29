using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour {

    public void GoToLevel()
    {
        

        char[] levelName = transform.parent.gameObject.name.ToCharArray();
        print(GameManager.level);
        GameManager.level = (int)char.GetNumericValue(levelName[levelName.Length - 1]);

        Application.LoadLevel(transform.parent.gameObject.name);

    }

    public void GoBack()
    {
        Application.LoadLevel("Menu");
    }
}
