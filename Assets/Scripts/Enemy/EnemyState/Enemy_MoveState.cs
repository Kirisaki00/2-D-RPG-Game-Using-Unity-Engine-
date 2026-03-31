using UnityEngine;

public class Enemy_MoveState : Enemy_GroundedState
{
    public Enemy_MoveState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }


    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(enemy.moveSpeed* enemy.facingDir, rb.linearVelocity.y);

        if (enemy.groundDeceted == false || enemy.wallDetected)
        {
            stateMachine.ChangeState(enemy.idealState);
            enemy.Flip();
        }
    }
}
