using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Arcade1942
{
    public abstract class BaseShoot : MonoBehaviour
    {
        [SerializeField] protected float m_FireRate = default;
        [SerializeField] protected List<BulletBarrel> m_Barrels = new List<BulletBarrel>();

        protected float mlastBulletTime = default; // Need to update mLastBulletTime in each TriggerShoot implementation. //Need to implement this properly

        public abstract void TriggerShoot();

        private void OnEnable()
        {
            mlastBulletTime = 0;
        }

        protected virtual void Update()
        {
            if (CanFireBullet())
                TriggerShoot();
        }

        protected virtual bool CanFireBullet()
        {
            if (mlastBulletTime == 0 || Time.time - mlastBulletTime >= m_FireRate)
                return true;

            return false;
        }
    }
}
