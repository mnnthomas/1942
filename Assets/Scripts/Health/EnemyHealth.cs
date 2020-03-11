using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Arcade1942
{
    /// <summary>
    /// EnemyHealth inherits from BaseHealth and handles health calculation on TakeDamage
    /// </summary>
    public class EnemyHealth : BaseHealth
    {

        //Spawns an explosion effect in place and puts the enemy back in object pool
        protected override void OnHealthDepleted()
        {
            ObjectPoolManager.pInstance.SpawnObject(m_ExplosionEffectName, transform.position);
            ObjectPoolManager.pInstance.ReturnToPool(gameObject);

            m_MessageReciever.pValue.SendMessage("OnEnemyDestroyed", gameObject);
        }

        public override void TakeDamage(float value)
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
