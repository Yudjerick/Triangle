using UnityEngine;
namespace Enemies{
    public abstract class EnemyState: ScriptableObject {
        public virtual void Enter(){}
        public virtual void FrameUpdate(){}
        public virtual void PhysicsUpdate(){}

        public virtual void OnTrigger(){
        }

        public virtual void Exit(){}
    }
}
