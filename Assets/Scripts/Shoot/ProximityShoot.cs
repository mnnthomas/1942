using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class ProximityShoot : BaseShoot
    {
        [SerializeField] private float m_ProximityDistance = default;
        [SerializeField] TargetTransform m_Target = default;
        
        //Shoot when object is within the defined proximity of player 
        public override bool ShootCondition()
        {
            if (Vector2.Distance(m_Target.pValue.position, transform.position) <= m_ProximityDistance)
                return true;

            return false;
        }
    }
}

