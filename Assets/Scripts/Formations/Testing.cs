using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Formation formation;
    public GameObject testObj;
    void Start()
    {
        print(formation.points);
        foreach (var pos in formation.points)
        {
        }
    }
    
    private void Update() {
        foreach (var pos in formation.points)
        {
            DebugExtension.DebugCylinder(pos, pos + Vector3.down * 0.1f, 0.1f);
            //Debug.DrawLine(pos, pos + Vector3.down * 0.1f);
        }
    }
}
