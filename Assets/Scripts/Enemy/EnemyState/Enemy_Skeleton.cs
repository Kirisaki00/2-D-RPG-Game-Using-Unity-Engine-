using UnityEngine;

public class Enemy_Skeleton : Enemy
{
    
    protected override void Awake()
    {
        base.Awake();
        idealState = new Enemy_IdealState(this, stateMachine, "ideal");
        moveState = new Enemy_MoveState(this, stateMachine, "move");
        attackState = new Enemy_AttackState(this, stateMachine, "attack");
        battleState = new Enemy_BattleState(this, stateMachine, "battle");
        deadState= new Enemy_DeadState(this, stateMachine,"ideal");
    }
    protected override void Start()
    {
        // base.Start();
        // anim.enabled=false;
        stateMachine.Initialize(idealState);
    }
}
