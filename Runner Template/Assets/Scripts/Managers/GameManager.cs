using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameStarted;



    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        isGameStarted = true;

        PlayerStateManager.instance.SwitchState(PlayerStateManager.instance.RunningState);
    }

    public void EndGame()
    {
        isGameStarted = false;
    }

}
