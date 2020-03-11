using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Arcade1942
{
    public class TargetTransformAssigner : MonoBehaviour
    {
        [SerializeField] private TargetTransform m_TargetTransform = default;

        private void OnEnable()
        {
            m_TargetTransform.pValue = transform;
            Destroy(this);
        }
    }
}
