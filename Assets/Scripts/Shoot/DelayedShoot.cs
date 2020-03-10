using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class DelayedShoot : BaseShoot
    {
        [SerializeField] private float m_Delay = default;

        private float mStartTime = default;

        private void OnEnable()
        {
            mStartTime = Time.time;
        }

        public override void TriggerShoot()
        {
            if(isActiveAndEnabled && Time.time - mStartTime >= m_Delay)
            {
                for (int i = 0; i < m_Barrels.Count; i++)
                    m_Barrels[i].Shoot();

                mlastBulletTime = Time.time;
            }
        }
    }
}
