using UnityEngine;

public class Player_AttackState : PlayerState
{
    public Player_AttackState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    private float attackVelocityTimer;
    private int comboAttackIndex = 0;
    private float lastTimeAttacked;
    private bool comboToIdeal;
    private float attackDir;
    public override void Enter()
    {
        base.Enter();
        triggerCalled = false;
        comboToIdeal = false;
        HandleComboAttackIndex();
        attackVelocityTimer = player.attackVelocityDuration;
        anim.SetInteger("BasicAttackIndex", comboAttackIndex);
        // player.SetVelocity(0, rb.linearVelocityY);
        if (player.moveInput.x != 0)
            attackDir = player.moveInput.x;
        else
            attackDir = player.facingDir;
        ApplyAttackVelocity();

    }
    public override void Update()
    {
        base.Update();
        HandleAttackVelocity();
        if (inputs.Player.Attack.WasPressedThisFrame())
            // comboToIdeal = true;
            HandleComboToIdealBool();
        attackVelocityTimer -= Time.deltaTime;
        if (triggerCalled)
            if (comboToIdeal)
            {
                anim.SetBool(animBoolName, false);
                player.EnterAttackStateWithDelay();
            }
            // stateMachine.ChangeState(player.attackState);
            else
                stateMachine.ChangeState(player.idealState);


    }
    public override void Exit()
    {
        base.Exit();
        lastTimeAttacked = Time.time;
        comboAttackIndex++;
    }
    private void HandleAttackVelocity()
    {
        attackVelocityTimer -= Time.deltaTime;
        if (attackVelocityTimer < 0)
            player.SetVelocity(0, rb.linearVelocityY);
    }
    private void ApplyAttackVelocity()
    {
        player.SetVelocity(player.attackVelocity[comboAttackIndex].x * attackDir, player.attackVelocity[comboAttackIndex].y);
    }
    private void HandleComboAttackIndex()
    {
        if (Time.time > lastTimeAttacked + player.comboAttackTimer)
            comboAttackIndex = 0;
        if (comboAttackIndex > 2)
            comboAttackIndex = 0;
    }
    private void HandleComboToIdealBool()
    {
        if (comboAttackIndex < 2)
            comboToIdeal = true;
    }
}
