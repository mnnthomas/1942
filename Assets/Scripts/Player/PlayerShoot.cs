using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// The PlayerShoot enables the barrels to shoot based on User Inputs.
    /// </summary>
    public class PlayerShoot : BaseShoot
    {
        [SerializeField] private string m_PrimaryWeaponKey = default;
     
        public override void TriggerShoot()
        {
            if(Input.GetButton(m_PrimaryWeaponKey))
            {
                for (int i = 0; i < m_Barrels.Count; i++)
                    m_Barrels[i].Shoot();
            }
        }
    }
}