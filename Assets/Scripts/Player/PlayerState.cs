using UnityEngine;

public abstract class PlayerState :EntityState
{
    protected Player player;
    protected PlayerInputSet inputs;
    public PlayerState(Player player,StateMachine stateMachine, string animBoolName):base(stateMachine,animBoolName)
    {
        this.player = player;
        anim = player.anim;
        rb = player.rb;
        inputs = player.inputs;
    }

    public override void Update()
    {
        base.Update();
        anim.SetFloat("yVelocity", rb.linearVelocityY);
        // anim.SetBool("jumpFall",player.jumpFall)
        if (inputs.Player.Dash.WasPressedThisFrame() && canDash())
            stateMachine.ChangeState(player.dashState);

    }
    public bool canDash()
    {
        if (player.wallDetected)
            return false;
        if (stateMachine.currentState == player.dashState)
            return false;
        return true;
    }
}
