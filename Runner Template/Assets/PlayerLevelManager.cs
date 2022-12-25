using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerLevelManager : MonoBehaviour
{
    public static PlayerLevelManager instance;

    public int playerLevel;

    [SerializeField] TextMeshPro levelText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerLevel = PlayerPrefs.GetInt("SavedPlayerLevel", 1);
        levelText.text = playerLevel.ToString();
    }

    public void ChangeLevel(int levelNumber,bool save)
    {
        playerLevel += levelNumber;
        if (playerLevel <= 0)
        {
            levelText.text = 0.ToString();
        }
        else
        {
            levelText.text = playerLevel.ToString();
        }
        if (save)
        {
            PlayerPrefs.SetInt("SavedPlayerLevel", playerLevel);
        }

        if (playerLevel <= 0)
        {
            PlayerStateManager.instance.SwitchState(PlayerStateManager.instance.FailedState);
        }
    }

    public void VSPlayer(int level)
    {
        if (playerLevel >= level)
        {
            playerLevel += level;
            levelText.text = playerLevel.ToString();
        }
        else if (playerLevel < level)
        {
            PlayerStateManager.instance.SwitchState(PlayerStateManager.instance.FailedState);
        }
    }
}
