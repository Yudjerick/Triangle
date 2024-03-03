using UnityEngine;

public abstract class EnemyState {
    public GameObject enemy {get; set;}
    public Vector3 goal {get;set;}
    public virtual void Enter(){}
    public virtual EnemyState FrameUpdate(){return this;}
    public virtual EnemyState PhysicsUpdate(){return this;}

    public virtual void Exit(){}
}