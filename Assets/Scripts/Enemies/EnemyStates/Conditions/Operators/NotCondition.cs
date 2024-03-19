namespace Enemies
{
    using NaughtyAttributes;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "NOT", menuName = "EnemyAI/Conditions/Operators/Not", order = 0)]
    
    public class NotCondition : Condition {
        [SerializeField, Expandable] private Condition invert;

        public override bool IsSatisfied(EnemyState enemyState)
        {
            return !invert.IsSatisfied(enemyState);
        }
    }
}