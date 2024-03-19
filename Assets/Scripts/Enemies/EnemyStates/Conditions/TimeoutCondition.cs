using System;
using UnityEngine;
namespace Enemies
{
    [CreateAssetMenu(fileName = "TimeoutCondition", menuName = "EnemyAI/Conditions/TimeoutCondition", order = 0)]
    public class TimeoutCondition : Condition
    {
        [SerializeField] private float exitTime;
        public override bool IsSatisfied(EnemyState enemyState)
        {
            return ((TimeState) enemyState).timePassed >= exitTime;
        }
    }
}