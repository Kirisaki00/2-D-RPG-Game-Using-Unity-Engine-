using Unity.VisualScripting;
using UnityEngine;

public class Player_DashState : PlayerState
{
    public Player_DashState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
    }
    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.facingDir * player.dashSpeed, 0);
        if (stateTimer < 0)
            if (player.groundDeceted)
                stateMachine.ChangeState(player.idealState);
            else
                // player.SetVelocity(0, rb.linearVelocityY);
                stateMachine.ChangeState(player.fallState);


        //Calcelling Dash on Wall detection--
        if (player.wallDetected)
            if (player.groundDeceted)
                stateMachine.ChangeState(player.idealState);
            else
                stateMachine.ChangeState(player.wallSlide);
    }
    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, 0);
    }
}
