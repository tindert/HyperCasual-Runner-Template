using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public static PlayerStateManager instance;
    public PlayerRunningState RunningState = new PlayerRunningState();
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerFailedState FailedState = new PlayerFailedState();
    public PlayerWinState WinState = new PlayerWinState();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentState = IdleState;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }
}
