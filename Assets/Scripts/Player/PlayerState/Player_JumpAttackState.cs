using UnityEngine;

public class Player_JumpAttackState : PlayerState
{
    public Player_JumpAttackState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    private bool touchedGround;
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(player.jumpAttackVelocity.x * player.facingDir, player.jumpAttackVelocity.y);
        touchedGround = false;
        triggerCalled = false;
    }
    public override void Update()
    {
        base.Update();
        if (player.groundDeceted && !touchedGround)
        {
            touchedGround = true;
            player.SetVelocity(0, rb.linearVelocityY);
            anim.SetTrigger("jumpAttackTrigger");
        }
        if (triggerCalled && player.groundDeceted)
            stateMachine.ChangeState(player.idealState);
            
            
    }
}
