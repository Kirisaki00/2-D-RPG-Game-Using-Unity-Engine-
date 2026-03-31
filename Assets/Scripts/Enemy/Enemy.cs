using UnityEngine;

public class Enemy : Entity
{
   public Enemy_IdealState idealState;
    public Enemy_MoveState moveState;
    public Enemy_AttackState attackState;
    public Enemy_BattleState battleState;
    public Enemy_DeadState deadState;
    
    [Header("Movement Details")]
    public float moveSpeed = 1.4f;
    public float idealTime = 2;

    [Header("Player Detection Details")]
    public Transform playerCheck;
    public LayerMask whatIsEnemy;
    public float playerCheckDistance;
    public Transform player;
    [Header("Battle Details")]
    public float battleMoveSpeed = 4f;
    public float attackDistance;
    public float battleTimeDuration = 5;


    public void TryEnterBattleState(Transform player)
    {
        if (stateMachine.currentState == battleState || stateMachine.currentState == attackState)
            return;
        this.player = player;
        stateMachine.ChangeState(battleState);
    }
    public void HandlePlayerDeath()
    {
        stateMachine.ChangeState(idealState);
    }
    public RaycastHit2D PlayerDetector()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCheck.position, Vector2.right * facingDir, playerCheckDistance, whatIsEnemy | whatIsGround);
        if (hit.collider == null || hit.collider.gameObject.layer != LayerMask.NameToLayer("Player"))
            return default;
        return hit;
    }
    public override void EntityDeath()
    {
        base.EntityDeath();
        stateMachine.ChangeState(deadState);
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x + (playerCheckDistance * facingDir), playerCheck.position.y));
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x+(facingDir * attackDistance), playerCheck.position.y));
    }
    private void OnEnable()
    {
        Player.OnPlayerDeath += HandlePlayerDeath;
    }
    private void OnDisable()
    {
        Player.OnPlayerDeath-=HandlePlayerDeath;
    }
}
