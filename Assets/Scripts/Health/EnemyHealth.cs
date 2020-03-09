using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Arcade1942
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float m_Health = default;
        [SerializeField] private float m_AutoDestroyDuration = default;
        [SerializeField] private Slider m_HealthSlider = default;


        public float pCurHealth { private set; get; }

        private float mStartTime;

            private void OnEnable()
        {
            pCurHealth = m_Health;
            mStartTime = Time.time;

            if (m_HealthSlider)
            {
                m_HealthSlider.maxValue = pCurHealth;
                m_HealthSlider.value = pCurHealth;
            }
        }

        private void Update()
        {
            if (Time.time - mStartTime >= m_AutoDestroyDuration && isActiveAndEnabled)
                OnHealthDepleted();
        }

        public void OnHealthDepleted()
        {
            mStartTime = default;
            pCurHealth = default;
            ObjectPoolManager.pInstance.ReturnToPool(gameObject);
        }

        public void TakeDamage(float value)
        {
            pCurHealth -= value;
            m_HealthSlider.value = pCurHealth;

            if (pCurHealth <= 0)
                OnHealthDepleted();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
                OnHealthDepleted();
        }
    }
}
