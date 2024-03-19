using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UltEvents;

namespace Enemies{
    [Serializable]
    public class StateNode
    {
        public EnemyState state;
        public List<Transition> transitions;
    }
}
