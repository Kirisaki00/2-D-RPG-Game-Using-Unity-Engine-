using UnityEngine;

public class Entity_Combact : MonoBehaviour
{
    // public Collider2D[] targetCollider;
    public float damage = 10;
    [Header("Target Detection")]
    [SerializeField] private Transform targetCheck;
    [SerializeField] private float targetCheckRadius;
    [SerializeField] private LayerMask whatIsTarget;
    public void PerformAttack()
    {
        
        foreach(var target in GetDetectedCollider())
        {
            Entity_Health targetHealth = target.GetComponent<Entity_Health>();
            targetHealth?.TakeDamage(damage,transform);
        }   
    }
    private Collider2D[] GetDetectedCollider()
    {
        return Physics2D.OverlapCircleAll(targetCheck.position, targetCheckRadius, whatIsTarget);
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetCheck.position, targetCheckRadius);
    }
}
