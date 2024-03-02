using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(fileName = "CircleFormation", menuName = "Formation/CircleFormation", order = 0)]
public class CircleFormation : Formation{
    [SerializeField] private float radius = 1f;
    [SerializeField] private List<Formation> formations;
    [SerializeField] private float offset = 0f;
    public override List<Vector3> points { get {
        List<Vector3> result = new List<Vector3>();
        float angle = 360f / formations.Count;
        for(int i = 0; i < formations.Count; i++){
            var vector = Quaternion.Euler(0, i * angle + offset, 0) * Vector3.forward * radius;
            foreach (var point in formations[i].points)
            {
                result.Add(vector + point);
            }
        }
        return result;
    }}
}