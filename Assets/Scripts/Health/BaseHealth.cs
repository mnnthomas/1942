using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// Objects with Health inherits BaseHealth 
    /// /// The bullet hitting an object searches for BaseHealth and sends its damange value through the TakeDamage abstract method
    /// </summary>
    public abstract class BaseHealth : MonoBehaviour
    {
        [SerializeField] protected float m_Health = default;
        [SerializeField] protected UIHealth m_UIHealth = default;
        [SerializeField] protected TargetTransform m_MessageReciever = default;
        [Header(" -- Explosion effects -- ")]
        [SerializeField] protected string m_ExplosionEffectName = default;

        public abstract void TakeDamage(float value);
        protected abstract void OnHealthDepleted();

        public float pCurHealth;

        protected virtual void OnEnable()
        {
            pCurHealth = m_Health;
            if(m_UIHealth)
                m_UIHealth.InitHealthBar(pCurHealth);
        }

        protected virtual void OnDisable()
        {
            pCurHealth = default;
        }
    }
}
