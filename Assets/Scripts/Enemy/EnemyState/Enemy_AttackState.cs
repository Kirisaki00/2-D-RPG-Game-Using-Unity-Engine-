using UnityEngine;

public class Enemy_AttackState : EnemyState
{
    private EnemyAudio enemyAudio;

    public Enemy_AttackState(Enemy enemy, StateMachine stateMachine, string animBoolName)
        : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enemy attack state entered");
        enemyAudio = enemy.GetComponent<EnemyAudio>();

        if (enemyAudio != null){
            Debug.Log("EnemyAudio found");
            enemyAudio.PlayAttackSound();
        }
        else
            Debug.LogWarning("EnemyAudio not found on enemy!");
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
            stateMachine.ChangeState(enemy.battleState);
    }
}