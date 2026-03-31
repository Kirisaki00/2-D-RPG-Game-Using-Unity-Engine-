using UnityEngine;

public class Enemy_BattleState : EnemyState
{

    public Enemy_BattleState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    private float lastTimeInBattle;
    private Transform player;
    public override void Enter()
    {
        base.Enter();
        // lastTimeInBattle = enemy.battleTimeDuration;
        // Debug.Log("Entered bitchi bitch");
        if (player == null)
            player = enemy.PlayerDetector().transform;
        if (player == null)
            player = enemy.player;
    }
    public override void Update()
    {
        base.Update();
        FacePlayer();
        if (enemy.PlayerDetector())
            lastTimeInBattle = Time.time;
        if (BattleTimeIsOver())
            stateMachine.ChangeState(enemy.idealState);
        if (WithinAttackRange())
            stateMachine.ChangeState(enemy.attackState);
        else
            enemy.SetVelocity(enemy.battleMoveSpeed * DirectionToPlayer(), rb.linearVelocityY);
    }
    private void FacePlayer()
    {
    if (player == null) return;

    bool playerOnRight = player.position.x > enemy.transform.position.x;
    if (playerOnRight && enemy.facingDir == -1)
        enemy.Flip();
    else if (!playerOnRight && enemy.facingDir == 1)
        enemy.Flip();
    }


    private bool BattleTimeIsOver()
    {
        if (Time.time > lastTimeInBattle + enemy.battleTimeDuration)
            return true;
        return false;
    }
    private bool WithinAttackRange()
    {
        if (DistanceToPlayer() < enemy.attackDistance)
            return true;
        return false;
    }
    private float DistanceToPlayer()
    {
        if (player == null)
            return float.MaxValue;
        return Mathf.Abs(player.position.x - enemy.transform.position.x);
    }
    private int DirectionToPlayer()
    {
        if (player == null)
            return 0;
        return player.transform.position.x > enemy.transform.position.x ? 1 : -1;
    }
}
