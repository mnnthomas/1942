﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Arcade1942
{
    /// <summary>
    /// EnemyHealth extends from IHealth and handles health calculation on TakeDamage
    /// </summary>
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float m_Health = default;
        [SerializeField] private UIHealth m_UIHealth = default;
        [SerializeField] private TargetTransform m_MessageReciever = default;
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

        //Spawns an explosion effect in place and puts the enemy back in object pool
        public void OnHealthDepleted()
        {
            ObjectPoolManager.pInstance.SpawnObject(m_ExplosionEffectName, transform.position);
            ObjectPoolManager.pInstance.ReturnToPool(gameObject);

            m_MessageReciever.pValue.SendMessage("OnEnemyDestroyed", gameObject);
        }

        public void TakeDamage(float value)
        {
            pCurHealth -= value;
            m_UIHealth.UpdateHealth(pCurHealth);

            if (pCurHealth <= 0)
                OnHealthDepleted();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Specific condition to immediately destroy object on collision with player
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
                OnHealthDepleted();
        }
    }
}
