using System;
using System.Collections;
using System.Collections.Generic;
using Leguar.TotalJSON;
using NaughtyAttributes;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Formation formation;
    public GameObject testObj;

    public String json;

    [Button("Make json")]
    void MakeJson(){
        if(formation is not null){
            IFormationData formationData = formation;
            json = JsonUtility.ToJson(formation);
        }
    }

    [Button("Parse json")]
    void ParseJson(){
        if(formation is not null){
            JsonUtility.FromJsonOverwrite(json, formation);
        }
    }

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
            DebugExtension.DebugCircle(pos, 0.1f);
        }
    }
}
