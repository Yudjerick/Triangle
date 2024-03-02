using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Lineformation", menuName = "Formation/Lineformation", order = 0)]
public class Lineformation : Formation
{
    [SerializeField] bool setOriginToCenter;
    [SerializeField] private List<Formation> formations;
    [SerializeField] private float gap = 0.2f;

    [SerializeField] private float rotationOffset = 0f;

    public override List<Vector3> points {get {
        List<Vector3> result = new List<Vector3>();
        float originOffset = setOriginToCenter ? (formations.Count - 1f) * gap / 2f : 0f;
        for (int i = 0; i < formations.Count; i++)
        {
            Vector3 vector = Quaternion.Euler(0f,rotationOffset,0f) * Vector3.forward;
            foreach (var point in formations[i].points)
            {
                result.Add(vector * (gap * i - originOffset) + point);
            }
        }
        return result;
    }}
}