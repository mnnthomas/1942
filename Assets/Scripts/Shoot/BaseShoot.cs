using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Arcade1942
{
    public abstract class BaseShoot : MonoBehaviour
    {
        [SerializeField] protected float m_FireRate = default;
        [SerializeField] protected List<BulletBarrel> m_Barrels = new List<BulletBarrel>();

        protected float mlastBulletTime = default;

        public abstract void TriggerShoot();

        protected virtual void Update()
        {
            if (CanFireBullet())
                TriggerShoot();
        }

        protected virtual bool CanFireBullet()
        {
            if (Time.time - mlastBulletTime >= m_FireRate)
            {
                mlastBulletTime = Time.time;
                return true;
            }
            return false;
        }
    }
}
