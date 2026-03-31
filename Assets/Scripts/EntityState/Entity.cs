using System.Collections;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    protected StateMachine stateMachine;
    public Transform groundCheck;

    [Header("Collision Detection")]
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float wallCheckDistance;
    public bool groundDeceted;
    public bool wallDetected;
    private bool facingRight = true;
    public int facingDir { get; private set; } = 1;

    private bool isKnocked;
    private Coroutine knockedBackCo;
    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine = new StateMachine();
        
    }
    
    protected virtual  void Start()
    {
        
    }
    protected virtual void Update()
    {
        HandleCollisionDetection();
        stateMachine.currentState.Update();
    }

    public void ReciveKnockBack(Vector2 knockBack, float knockBackDuration)
    {
        if (knockedBackCo != null)
            StopCoroutine(knockedBackCo);
        knockedBackCo = StartCoroutine(KnockedBackCo(knockBack, knockBackDuration));
    }

    private IEnumerator KnockedBackCo(Vector2 knockBack, float knockBackDuration)
    {
        isKnocked = true;
        rb.linearVelocity = knockBack;
        yield return new WaitForSeconds(knockBackDuration);
        rb.linearVelocity = Vector2.zero;
        isKnocked = false;
    }
    public void SetVelocity(float xVelocity, float yVelocity)
    {
        if (isKnocked)
            return;
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
        HandleFlip();
    }
    public void HandleFlip()
    {
        if (rb.linearVelocityX > 0 && facingRight == false)
            Flip();
        else if (rb.linearVelocityX < 0 && facingRight == true)
            Flip();
    }
    public void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
        facingDir = facingDir * -1;
    }
    private void HandleCollisionDetection()
    {
        groundDeceted = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(transform.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
    }
    public void CalledAnimationTrigger()
    {
        stateMachine.currentState.CalledAnimationTrigger();
    }
    public virtual void EntityDeath()
    {
        
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + new Vector3(0, -groundCheckDistance));
        if (facingRight)
            Gizmos.DrawLine(transform.position, transform.position + new Vector3(wallCheckDistance*facingDir, 0));
        else if(!facingRight)
            Gizmos.DrawLine(transform.position, transform.position + new Vector3(wallCheckDistance*facingDir, 0));
    }
    
}
