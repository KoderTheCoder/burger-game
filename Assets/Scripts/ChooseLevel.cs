using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseLevel : MonoBehaviour {
    public GameObject lockImg;
    char[] levelName;
    public Image[] starImgs;
    public Sprite fullStar;
    int levelNumber;

    void Start()
    {
        levelName = transform.parent.gameObject.name.ToCharArray();
        levelNumber = (int)char.GetNumericValue(levelName[levelName.Length - 1]);
        print(levelNumber);
        if(levelNumber != 1)
        {
            if (PlayerPrefs.GetInt("Level" + ((levelNumber - 1).ToString() + "Stars")) > 0)
            {
                lockImg.SetActive(false);
            }
        }

        int stars = PlayerPrefs.GetInt("Level" + (levelNumber.ToString() + "Stars"));
        print(stars.ToString());
        if (stars > 0)
        {
            for(int i = 0; i < stars; ++i)
            {
                starImgs[i].sprite = fullStar;
            }
        }
    }
    public void GoToLevel()
    {
        GameManager.level = levelNumber;
        print(GameManager.level);
        if (levelNumber != 1)
        {
            if (PlayerPrefs.GetInt("Level" + ((GameManager.level - 1).ToString() + "Stars")) > 0)
            {
                Application.LoadLevel(transform.parent.gameObject.name);
            }
        }
        else
        {
            Application.LoadLevel(transform.parent.gameObject.name);
        }
    }

    public void GoBack()
    {
        Application.LoadLevel("Menu");
    }
}
