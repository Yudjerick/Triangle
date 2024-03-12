using System.Collections.Generic;
using UnityEngine;
namespace Enemies{
    
    [CreateAssetMenu(fileName = "EnemyStateMachine", menuName = "EnemyAI/Statemachine", order = 0)]
    public class EnemyStateMachine : ScriptableObject {
        [SerializeField] List<StateNode> stateNodes;

        public void SetEnemyState(){
            
        }
    }
}
