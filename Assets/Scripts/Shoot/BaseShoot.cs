using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Arcade1942
{
    /// <summary>
    /// An abstract BaseShoot class which handles the conditions for shooting after a fireRateDelay, shooting object's visiblity and Inherited class's condition
    /// The abstract method ShootCondition is checked in update to enable shooting
    /// </summary>
    public abstract class BaseShoot : MonoBehaviour
    {
        [SerializeField] protected float m_FireRate = default;
        [SerializeField] protected List<BulletBarrel> m_Barrels = new List<BulletBarrel>();

        protected float mlastBulletTime;
        protected bool mIsVisible;

        public abstract bool ShootCondition();

        protected virtual void OnEnable()
        {
            mlastBulletTime = 0;
        }

        protected virtual void OnBecameInvisible()
        {
            mIsVisible = false;
        }

        protected virtual void OnBecameVisible()
        {
            mIsVisible = true;
        }

        protected virtual void TriggerShoot()
        {
            for (int i = 0; i < m_Barrels.Count; i++)
                m_Barrels[i].Shoot();

            mlastBulletTime = Time.time;
        }

        protected virtual void Update()
        {
            if (isActiveAndEnabled && mIsVisible && IsFireRateCooldownReady() && ShootCondition())
                TriggerShoot();
        }

        protected virtual bool IsFireRateCooldownReady()
        {
            if (mlastBulletTime == 0 || Time.time - mlastBulletTime >= m_FireRate)
                return true;

            return false;
        }
    }
}
