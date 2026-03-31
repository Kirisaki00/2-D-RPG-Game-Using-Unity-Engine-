using UnityEngine;

public class Player_IdealState: PlayerGroundedState
{
    public Player_IdealState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, rb.linearVelocityY);
    }
    public override void Update()
    {
        base.Update();
        if (player.moveInput.x != 0)
            stateMachine.ChangeState(player.moveState);

        // if (player.inputs.Player.Jump.WasPressedThisFrame())
        //     player.SetVelocity(rb.linearVelocityX, player.jumpForce);
    }
}
