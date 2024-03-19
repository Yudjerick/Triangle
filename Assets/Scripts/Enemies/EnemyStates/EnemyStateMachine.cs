using System.Collections.Generic;
using UnityEngine;
namespace Enemies{
    
    [CreateAssetMenu(fileName = "EnemyStateMachine", menuName = "EnemyAI/Statemachine", order = 0)]
    public class EnemyStateMachine : ScriptableObject {
        [SerializeField] List<StateNode> stateNodes;

        [HideInInspector] public EnemyAI enemy;

        private EnemyState currentState;

        [SerializeField] EnemyState initialState;

        public void Init(EnemyAI enemy){
            this.enemy = enemy;
            currentState = Instantiate(initialState);
            currentState.enemy = enemy;
        }

        public void Update(){
            currentState.FrameUpdate();
            foreach (var node in stateNodes)
            {
                if(node.state.GetType() == currentState.GetType()){
                    foreach (var transition in node.transitions)
                    {
                        
                        if(transition.condition.IsSatisfied(currentState)){
                            Debug.Log(transition.nextState.GetType());
                            SetEnemyState(transition.nextState);
                        }
                    }
                }
            }
        }

        public void SetEnemyState(EnemyState statePrototype){
            currentState.Exit();
            Destroy(currentState);
            currentState = Instantiate(statePrototype);
            currentState.enemy = enemy;
        }
    }
}
