using System.Text.RegularExpressions;
using UnityEngine;

public class Player_FallState : Player_AirState
{

    public Player_FallState( Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Update()
    {
        base.Update();
        if (player.groundDeceted)
            stateMachine.ChangeState(player.idealState);
        if (player.wallDetected)
            stateMachine.ChangeState(player.wallSlide);
    }
}
