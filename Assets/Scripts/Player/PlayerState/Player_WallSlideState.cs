using UnityEngine;

public class Player_WallSlideState : PlayerState
{
    public Player_WallSlideState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Update()
    {
        base.Update();
        HandleWallSlide();
        if (player.groundDeceted)
        {
            stateMachine.ChangeState(player.idealState);
            player.Flip();
        }
        if (!player.groundDeceted && !player.wallDetected)
            stateMachine.ChangeState(player.fallState);
        if (inputs.Player.Jump.WasPressedThisFrame())
            stateMachine.ChangeState(player.wallJump);
    }
    private void HandleWallSlide()
    {
        if (player.moveInput.y < 0)
            player.SetVelocity(player.moveInput.x, rb.linearVelocityY);
        else
            player.SetVelocity(player.moveInput.x, rb.linearVelocityY * player.wallSlideSpeedMultiplier);
    }
}
