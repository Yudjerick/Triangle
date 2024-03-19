using UnityEngine;

namespace Enemies{
    public abstract class Condition : ScriptableObject {
        public abstract bool IsSatisfied(EnemyState enemyState);
    }   

}
