using UnityEngine;
using System;
using UltEvents;
using Enemies;
using NaughtyAttributes;

[Serializable]
public class Transition
{
    [Expandable]
    public Condition condition;
    public EnemyState nextState;
}