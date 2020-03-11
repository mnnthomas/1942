using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float m_Health = default;
        [SerializeField] private UIHealth m_UIHealth = default;
        [SerializeField] private TargetTransform m_MessageReciever = default;
        [Range(0, 100)]
        [SerializeField] private float m_LowHealthPercent = default;

        [Header(" -- Explosion effects -- ")]
        [SerializeField] private string m_ExplosionEffectName = default;

        public float pCurHealth { private set; get; }

        private void OnEnable()
        {
            pCurHealth = m_Health;
            m_UIHealth.InitHealthBar(pCurHealth);
        }

        private void OnDisable()
        {
            pCurHealth = default;
        }

        public void OnHealthDepleted()
        {
            ObjectPoolManager.pInstance.SpawnObject(m_ExplosionEffectName, transform.position);
            m_MessageReciever.pValue.SendMessage("OnPlayerDestroyed");
        }

        public void TakeDamage(float value)
        {
            pCurHealth -= value;
            m_UIHealth.UpdateHealth(pCurHealth);

            if (pCurHealth / m_Health * 100 <= m_LowHealthPercent)
                m_UIHealth.Blink(true);
            else if (pCurHealth / m_Health * 100 > m_LowHealthPercent)
                m_UIHealth.Blink(false);

            if (pCurHealth <= 0)
                OnHealthDepleted();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Specific condition to immediately destroy object on collision with player
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                OnHealthDepleted();
        }
    }
}

