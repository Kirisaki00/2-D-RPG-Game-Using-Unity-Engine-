using System;
using System.Collections;
using UnityEngine;

public class Player : Entity
{
    public static event Action OnPlayerDeath;
    public PlayerInputSet inputs { get; private set; }
    
    public Player_IdealState idealState{ get; private set; }
    public Player_MoveState moveState { get; private set; }
    public Player_JumpState jumpState { get; private set; }
    public Player_FallState fallState { get; private set; }
    public Player_WallSlideState wallSlide { get; private set; }
    public Player_WallJumpState wallJump { get; private set; }
    public Player_DashState dashState { get; private set; }
    public Player_AttackState attackState { get; private set; }
    public Player_JumpAttackState jumpAttackState { get; private set; }
    public Player_DeadState deadState {get; private set;}
    public Vector2 moveInput { get; private set; }
    [Header("Attack Details")]
    public Vector2[] attackVelocity;
    public float comboAttackTimer = 1;
    private Coroutine ComboToIdeal;
    public Vector2 jumpAttackVelocity;
    
    [Space]
    public float attackVelocityDuration = .3f;
    [Header("Movement Details")]
    public float moveSpeed;
    public float jumpForce;
    
    [Range(0, 1)]
    public float inAirMoveMultiplier = .7f;
    
    [Range(0, 1)]
    public float wallSlideSpeedMultiplier = .3f;
    public Vector2 wallJumpDir;
    [Space]
    public float dashDuration = .25f;
    public float dashSpeed = 20;

    protected override void Awake()
    {
        base.Awake();

        inputs = new PlayerInputSet();
        idealState = new Player_IdealState(this, stateMachine, "Ideal");
        moveState = new Player_MoveState(this, stateMachine, "Move");
        jumpState = new Player_JumpState(this, stateMachine, "jumpFall");
        fallState = new Player_FallState(this, stateMachine, "jumpFall");
        wallSlide = new Player_WallSlideState(this, stateMachine, "WallSlide");
        wallJump = new Player_WallJumpState(this, stateMachine, "wallJump");
        dashState = new Player_DashState(this, stateMachine, "Dash");
        attackState = new Player_AttackState(this, stateMachine, "attack");
        jumpAttackState = new Player_JumpAttackState(this, stateMachine, "jumpAttack");
        deadState= new Player_DeadState(this,stateMachine,"dead");
    }
    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idealState);
    }
    public override void EntityDeath()
    {
        base.EntityDeath();
        OnPlayerDeath?.Invoke();
        stateMachine.ChangeState(deadState);
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputs.Player.Movement.canceled += ctx => moveInput = Vector2.zero;

    }
    private void OnDisable()
    {
        inputs.Disable();
    }
    public void EnterAttackStateWithDelay()
    {
        if (ComboToIdeal != null)
            StopCoroutine(EnterAttackStateWithDelayCo());
        ComboToIdeal=StartCoroutine(EnterAttackStateWithDelayCo());
    }
    private IEnumerator EnterAttackStateWithDelayCo()
    {
        yield return new WaitForEndOfFrame();
        stateMachine.ChangeState(attackState);
    }
    
}
