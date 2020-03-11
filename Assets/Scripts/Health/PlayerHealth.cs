using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class PlayerHealth : BaseHealth
    {
        [Range(0, 100)]
        [SerializeField] private float m_LowHealthPercent = default;

        protected override void OnHealthDepleted()
        {
            ObjectPoolManager.pInstance.SpawnObject(m_ExplosionEffectName, transform.position);
            m_MessageReciever.pValue.SendMessage("OnPlayerDestroyed");
        }

        public override void TakeDamage(float value)
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

