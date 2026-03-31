using UnityEngine;

public class Player_WallJumpState : PlayerState
{
    // private float wallJumpTime = 0.2f;  // ignore wall for 0.2 seconds
    // private float wallJumpTimer;

    public Player_WallJumpState(Player player, StateMachine stateMachine, string animBoolName)
        : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // wallJumpTimer = wallJumpTime;

        // Jump away from the wall
        player.SetVelocity(-player.facingDir * player.wallJumpDir.x, player.wallJumpDir.y);
    }

    public override void Update()
    {
        base.Update();

        // wallJumpTimer -= Time.deltaTime;

        // Switch to fall once we start moving down
        if (rb.linearVelocityY < 0)
        {
            stateMachine.ChangeState(player.fallState);
            return;
        }

        // Only recheck wall after short delay
        if (player.wallDetected)
        {
            stateMachine.ChangeState(player.wallSlide);
            return;
        }
    }
}
