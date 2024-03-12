using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Enemies{
    [Serializable]
    public class StateNode
    {
        public EnemyState state;
        public List<Action> condition;
    }
}
