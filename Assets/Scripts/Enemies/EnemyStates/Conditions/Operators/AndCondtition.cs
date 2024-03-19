using UnityEngine;
namespace Enemies
{
    using NaughtyAttributes;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "AND", menuName = "EnemyAI/Conditions/Operators/And", order = 0)]
    public class AndCondtition : Condition
    {
        [Expandable,SerializeField] private Condition conditionA;
        [Expandable,SerializeField] private Condition conditionB;
        public override bool IsSatisfied(EnemyState enemyState)
        {
            return conditionA.IsSatisfied(enemyState) && conditionB.IsSatisfied(enemyState);
        }
    }
}