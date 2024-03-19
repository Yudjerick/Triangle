using UnityEngine;
namespace Enemies
{

    [CreateAssetMenu(fileName = "PlayerTooCloseCondition", menuName = "EnemyAI/Conditions/PlayerTooCloseCondition", order = 0)]
    class PlayerTooCloseCondition : Condition
    {
        [SerializeField] private float triggerDistance;
        public override bool IsSatisfied(EnemyState state)
        {
            return Vector3.Distance(state.enemy.transform.position, GameObject.FindWithTag("Player").transform.position) <= triggerDistance;
        }
    }

}
