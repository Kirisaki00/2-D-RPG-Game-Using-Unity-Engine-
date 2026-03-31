using Unity.VisualScripting;
using UnityEngine;

public class EnemyState : EntityState
{
    protected Enemy enemy;
    public float battleAnimSpeedMultiplier=2;
    public EnemyState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(stateMachine, animBoolName)
    {
        this.enemy = enemy;
        rb = enemy.rb;
        anim = enemy.anim;
    }
    public override void Update()
    {
        base.Update();
        // if(Input.GetKeyDown(KeyCode.Mouse0))
        // stateMachine.ChangeState(enemy.attackState);
        anim.SetFloat("xVelocity", rb.linearVelocityX);
        anim.SetFloat("battleAnimSPeedMultiplier", battleAnimSpeedMultiplier);
    }

}

