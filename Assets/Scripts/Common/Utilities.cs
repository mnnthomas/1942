using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// A general Utilities class to hold needed helper classes/methods
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// A class to hold min and max float
        /// </summary>
        [System.Serializable]
        public class MinMax
        {
            public float Min;
            public float Max;

            public MinMax()
            {
            }

            public MinMax(float inMin, float inMax)
            {
                Max = inMax;
                Min = inMin;
            }

            public bool IsInRange(float inValue)
            {
                if (inValue < Min || inValue > Max)
                    return false;
                return true;
            }
        }

        /// <summary>
        /// A rangemap to find the mapped value between two floats dynamically.
        /// </summary>
        [System.Serializable]
        public struct RangeMap
        {
            [System.Serializable]
            public struct Map
            {
                public float _Value;
                public float _MappedValue;
            }

            public Map _Min;
            public Map _Max;

            public float GetMappedValue(float num)
            {
                return ((num - _Min._Value) / (_Max._Value - _Min._Value) * (_Max._MappedValue - _Min._MappedValue)) + _Min._MappedValue;
            }
        }

        public static bool IsPositiveValue(float value)
        {
            return value > 0;
        }
    }
}
