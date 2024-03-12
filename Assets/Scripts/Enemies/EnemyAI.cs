using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Enemies {
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private bool isLeader;

        [SerializeField] private List<EnemyAI> minions;
        [SerializeField] private Formation formation;

        private List<Vector3> _avaliablePoints;
    }

}
