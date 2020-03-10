using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// Destroys an object after a specified duration
    /// Handles whether the object can be placed back in ObjectPool or destroyed completely
    /// </summary>
    public class ObjectSelfDestroy : MonoBehaviour
    {
        [SerializeField] private bool m_CanReturnToPool = false;
        [SerializeField] private float m_SelfDestructDuration = default;

        private float mStartTime;
        private bool isDestroying = default;

        private void OnEnable()
        {
            mStartTime = Time.time;
            isDestroying = false;
        }

        private void Update()
        {
            if (Time.time - mStartTime >= m_SelfDestructDuration && !isDestroying)
            {
                isDestroying = true;
                SelfDestruct();
            }
        }

        private void SelfDestruct()
        {
            if (m_CanReturnToPool && ObjectPoolManager.pInstance != null)
                ObjectPoolManager.pInstance.ReturnToPool(gameObject);
            else
                Destroy(gameObject);
        }
    }
}
