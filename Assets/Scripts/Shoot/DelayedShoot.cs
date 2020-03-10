using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class DelayedShoot : BaseShoot
    {
        [SerializeField] private float m_Delay = default;

        private float mStartTime = default;

        protected override void OnEnable()
        {
            mStartTime = Time.time;
        }

        //Shoot after an initial delay
        public override bool ShootCondition()
        {
            if(Time.time - mStartTime >= m_Delay)
                return true;

            return false;
        }
    }
}
