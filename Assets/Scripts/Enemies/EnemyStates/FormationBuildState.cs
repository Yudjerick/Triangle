using UnityEngine;

public class FormationBuildState : EnemyState
{
    private Rigidbody rb;
    public FormationBuildState(GameObject enemy){
        this.enemy = enemy;
        rb = enemy.GetComponent<Rigidbody>();
    }
    public override EnemyState PhysicsUpdate()
    {
        rb.velocity = (goal - enemy.transform.position).normalized;
        if((enemy.transform.position - goal).magnitude <= 0.01f){
            rb.velocity = Vector3.zero;
            return new NeutralState();
        }
        return base.PhysicsUpdate();
    }
}