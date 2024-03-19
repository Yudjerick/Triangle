using UnityEngine;
namespace Enemies
{

    [CreateAssetMenu(fileName = "ChasingState", menuName = "EnemyAI/States/ChasingState", order = 0)]
    class ChasingState: TimeState
    {
        [SerializeField] private float speed;
        public override void FrameUpdate()
        {
            
            enemy.transform.Translate((GameObject.FindGameObjectWithTag("Player").transform.position
                 - enemy.transform.position).normalized * speed * Time.deltaTime);

            timePassed += Time.deltaTime;
        }
    }
}