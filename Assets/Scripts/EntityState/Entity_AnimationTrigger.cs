using UnityEngine;

public class Entity_AnimationTrigger : MonoBehaviour
{
    private Entity entity;
    private Entity_Combact entityCombact;
    void Awake()
    {
        entity = GetComponentInParent<Entity>();
        entityCombact = GetComponentInParent<Entity_Combact>();
    }
    private void CurrentAttackTrigger()
    {
        entity.CalledAnimationTrigger();
    }
    private void AttackTrigger()
    {
        entityCombact.PerformAttack();
        // Debug.Log("Entered");
    }
}
