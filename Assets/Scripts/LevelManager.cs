using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public List<Ingredient> burgerStack;
    public Text score;
    public IDictionary<string, int> sideTaskNumbers = new Dictionary<string, int>();
    public Sprite[] sprites;
    int stars;

    public GameObject deathMenu;

    public Image[] starImages;
    public Sprite emptyStar;
    public Sprite fullStar;

    // Use this for initialization
    void Start () {
        burgerStack = new List<Ingredient>();
        int sideTaskLimit = 7 + GameManager.level;
        int limitHolder = 0;
        for(int i = 0; i < sprites.Length && limitHolder < sideTaskLimit; i++)
        {
            int rand = Random.Range(0, sideTaskLimit / 2);
            sideTaskNumbers[sprites[i].name] = rand;
            limitHolder += rand;
        }

        CheckForPlayerPrefs();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Stack: " + (burgerStack.Count - 1).ToString();
	}

    public void endGame()
    {
        print(GameManager.level.ToString());
        if (CompletedSideTask() && PlayerPrefs.GetInt("Level" + GameManager.level.ToString() + "CompletedTask")==0)
        {
            PlayerPrefs.SetInt("Level" + GameManager.level.ToString() + "Stars", stars + 1);
            PlayerPrefs.SetInt("Level" + GameManager.level.ToString() + "CompletedTask", 1);
            print("true1");
        }

        if(burgerStack.Count - 1 > 10 && PlayerPrefs.GetInt("Level" + GameManager.level.ToString() + "BeatScore") == 0)
        {
            PlayerPrefs.SetInt("Level" + GameManager.level.ToString() + "Stars", stars + 1);
            PlayerPrefs.SetInt("Level" + GameManager.level.ToString() + "BeatScore", 1);
            print("true2");
        }

        if(burgerStack.Count - 1 > 30 && PlayerPrefs.GetInt("Level" + GameManager.level.ToString() + "BeatTopScore") == 0)
        {
            PlayerPrefs.SetInt("Level" + GameManager.level.ToString() + "Stars", stars + 1);
            PlayerPrefs.SetInt("Level" + GameManager.level.ToString() + "BeatTopScore", 1);
            print("true1");
        }
        

        stars = stars = PlayerPrefs.GetInt("Level" + GameManager.level.ToString() + "Stars");
        for (int i = 0; i < stars; ++i)
        {
            starImages[i].sprite = fullStar;
        }
        Time.timeScale = 0;
        deathMenu.SetActive(true);
    }

    bool CompletedSideTask()
    {
        IDictionary<string, int> ingredientsTally = new Dictionary<string, int>();
        for (int i = 0; i < sprites.Length; ++i)
        {
            ingredientsTally[sprites[i].name] = 0;
        }
        

        foreach (Ingredient ing in burgerStack)
        {
            foreach (Sprite spr in sprites)
            {
                if (spr.name == ing.gameObject.GetComponent<SpriteRenderer>().sprite.name)
                {
                    ingredientsTally[spr.name] += 1;
                    break;
                }
            }
        }

        
        foreach (Sprite spr in sprites)
        {
            if (sideTaskNumbers.ContainsKey(spr.name))
            {
                if (ingredientsTally[spr.name] < sideTaskNumbers[spr.name])
                {
                    return false;
                }
            }
        }
        return true;
    }

    void CheckForPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Level" + GameManager.level.ToString() + "Stars"))
        {
            stars = PlayerPrefs.GetInt("Level" + GameManager.level.ToString() + "Stars");
        }
        else
        {
            PlayerPrefs.SetInt("Level" + GameManager.level.ToString() + "Stars", 0);
        }

        if (!PlayerPrefs.HasKey("Level" + GameManager.level.ToString() + "CompletedTask"))
        {
            PlayerPrefs.SetInt("Level" + GameManager.level.ToString() + "CompletedTask", 0);
        }

        if (!PlayerPrefs.HasKey("Level" + GameManager.level.ToString() + "BeatScore"))
        {
            PlayerPrefs.SetInt("Level" + GameManager.level.ToString() + "BeatScore", 0);
        }

        if (!PlayerPrefs.HasKey("Level" + GameManager.level.ToString() + "BeatTopScore"))
        {
            PlayerPrefs.SetInt("Level" + GameManager.level.ToString() + "BeatTopScore", 0);
        }
    }
}
