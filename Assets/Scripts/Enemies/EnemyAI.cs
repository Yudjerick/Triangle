using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private bool isLeader;

    [SerializeField] private List<EnemyAI> minions;
    [SerializeField] private Formation formation;

    private List<Vector3> _avaliablePoints;
    private EnemyState _enemyState;
    void Start()
    {
        minions = FindObjectsOfType<EnemyAI>().ToList();
        _enemyState = new NeutralState();
    }
 
    // Update is called once per frame
    void Update()
    {
        _enemyState = _enemyState.FrameUpdate();
    }

    private void FixedUpdate() {
        _enemyState = _enemyState.PhysicsUpdate();
    }

    private void OnTriggerEnter(Collider other) {
        if(isLeader && other.CompareTag("Player") && _enemyState is NeutralState){
            _avaliablePoints = formation.points.Select(x => transform.position + x).ToList();
            _enemyState = new FormationBuildState(gameObject);
            Vector3 closest = _avaliablePoints[0];
            foreach (var minion in minions)
            {
                if(_avaliablePoints.Count <= 0){
                    break;
                }
                minion._enemyState = new FormationBuildState(minion.gameObject);
                closest = _avaliablePoints[0];
                foreach (var point in _avaliablePoints)
                {
                    if((closest - minion.transform.position).magnitude > (point - minion.transform.position).magnitude){
                        closest = point;
                    }
                }
                minion._enemyState.goal = closest;
                _avaliablePoints.Remove(closest);

                print(_avaliablePoints.Count);
            }
        }
    }
}
