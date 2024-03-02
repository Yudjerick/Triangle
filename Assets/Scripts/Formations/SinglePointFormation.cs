using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SinglePointFormation", menuName = "Formation/SinglePointFormation", order = 0)]
public class SinglePointFormation : Formation
{
    public override List<Vector3> points => new List<Vector3>{Vector3.zero};
}
