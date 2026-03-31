using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Update()
    {
        base.Update();
        isAttacking();
        if (rb.linearVelocityY < 0 && !player.groundDeceted)
            stateMachine.ChangeState(player.fallState);
        if (inputs.Player.Jump.WasPressedThisFrame())
            stateMachine.ChangeState(player.jumpState);



    }
    public void isAttacking()
    {
        if (inputs.Player.Attack.WasPressedThisFrame() )
            stateMachine.ChangeState(player.attackState);
    }
}
