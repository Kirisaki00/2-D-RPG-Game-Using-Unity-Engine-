using UnityEngine;

public class Entity_Health : MonoBehaviour
{
    private Entity_VFX entityVFX;
    private Entity entity;
    [SerializeField] protected float maxHp = 100;
    [SerializeField] protected float currHp;
    [SerializeField] protected bool isDead;
    [Header("On Damage KnockBack")]
    [SerializeField] private Vector2 knockBackPower = new Vector2(1.5f, 2.5f);
    [SerializeField] private Vector2 heavyKnockBackPower = new Vector2(7, 7);
    [SerializeField] private float knockBackDuration = .2f;
    [SerializeField] private float heavyKnockBackPowerDuration = .5f;
    [Header("On Heavy KnockBack")]
    [SerializeField] private float heavyDamageThreshold = .3f;

    protected virtual void Awake()
    {
        entityVFX = GetComponent<Entity_VFX>();
        entity = GetComponent<Entity>();

        currHp = maxHp;
    }
    public virtual void TakeDamage(float damage,Transform transform)
    {
        if (isDead)
            return;
        Vector2 knockBack = CalculateKnockBack(damage,transform);
        entity.ReciveKnockBack(knockBack, CalculateDuration(damage));
        entityVFX.PlayOnDamageVFX();
        ReduceHp(damage);
    }
    protected void ReduceHp(float damage)
    {
        currHp -= damage;
        if (currHp <= 0)
            Die();
    }
    protected void Die()
    {
        isDead = true;
        entity.EntityDeath();
    }
    private Vector2 CalculateKnockBack(float damage, Transform damageDealer)
    {
        int direction = transform.position.x > damageDealer.position.x ? 1 : -1;
        Vector2 knockBack = IsHeavyDamage(damage) ? heavyKnockBackPower : knockBackPower;
        knockBack.x = knockBack.x * direction;
        return knockBack;
    }
    private float CalculateDuration(float damage) => IsHeavyDamage(damage) ? heavyKnockBackPowerDuration : knockBackDuration;

    private bool IsHeavyDamage(float damage) => damage / maxHp > heavyDamageThreshold;
}
