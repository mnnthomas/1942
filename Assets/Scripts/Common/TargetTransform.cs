using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    [CreateAssetMenu(menuName = "Arcade1942/ProximityTarget")]
    public class TargetTransform : ScriptableObject
    {
        public Transform pValue { get; set; }
    }
}
