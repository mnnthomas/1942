using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class ProximityShoot : BaseShoot
    {
        [SerializeField] private float m_ProximityDistance = default;

        private bool isVisible;

        public void OnBecameInvisible()
        {
            isVisible = false;
        }

        public void OnBecameVisible()
        {
            isVisible = true;
        }

        public override void TriggerShoot()
        {
            if(isVisible && isActiveAndEnabled && Vector2.Distance(PlayerMovement.pPlayer.transform.position, transform.position) <= m_ProximityDistance)
            {
                for (int i = 0; i < m_Barrels.Count; i++)
                    m_Barrels[i].Shoot();

                mlastBulletTime = Time.time;
            }
        }
    }
}

