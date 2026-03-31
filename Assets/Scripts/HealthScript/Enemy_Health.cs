using UnityEngine;

public class Enemy_Health : Entity_Health
{
    private Enemy enemy => GetComponent<Enemy>();
    public override void TakeDamage(float damage, Transform transform)
    {
        base.TakeDamage(damage, transform);
        // if (transform.CompareTag("Player"))
        if(isDead)
            return;
        if (transform.GetComponent<Player>() != null)
            enemy.TryEnterBattleState(transform);
        

    }
}
