using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFailedState : PlayerBaseState
{
    private Animator playerAnim;
    public override void EnterState(PlayerStateManager player)
    {
        playerAnim = player.GetComponentInChildren<Animator>();

        GameManager.instance.EndGame();

        CanvasManager.instance.FailUI();
        //Death Animations
        //Death Sounds
        //Death Effects
    }

    public override void UpdateState(PlayerStateManager player)
    {

    }

    public override void OnTriggerEnter(PlayerStateManager player, Collider other)
    {

    }
}
