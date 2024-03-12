using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(fileName = "NeautralState", menuName = "EnemyAI/States/Neutral", order = 0)]

    public class NeutralState : EnemyState
    {
        public bool SeesPlayer(){
            return false;
        }
    }
}
