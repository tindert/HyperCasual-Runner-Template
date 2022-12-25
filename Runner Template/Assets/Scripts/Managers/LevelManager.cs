using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int levelNumber;

    [SerializeField] private Image[] levelIndicators;
    [SerializeField] private TextMeshProUGUI[] levelNumbers;

    [SerializeField] private Sprite defaultSprite, passedSprite, trophySprite, currentSprite;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        levelNumber = PlayerPrefs.GetInt("CurrentLevelNumber", 1);

        for (int i = 0; i < levelNumber%10; i++)
        {
            if (i == levelNumber%10)
            {
                levelIndicators[i].sprite = currentSprite;
                Debug.Log("current");
                return;
            }
            levelIndicators[i].sprite = passedSprite;
        }
        int num = levelNumber / 10;
        for (int i = 1; i < 10; i++)
        {
            if (num != 0)
            {
                levelNumbers[i - 1].text = num.ToString() + i.ToString();
            }
            else
            {
                levelNumbers[i - 1].text = i.ToString();
            }
        }
    }

    public void IncreaseLevelNumber()
    {
        PlayerPrefs.SetInt("CurrentLevelNumber", levelNumber + 1);
    }
}
