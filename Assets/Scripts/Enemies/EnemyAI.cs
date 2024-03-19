using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Enemies {
    public class EnemyAI : MonoBehaviour
    {

        [SerializeField] private EnemyStateMachine stateMachine;

        private void Start() {
            stateMachine = Instantiate(stateMachine);
            stateMachine.Init(this);
        }

        private void Update() {
            stateMachine.Update();
        }
    }

}
