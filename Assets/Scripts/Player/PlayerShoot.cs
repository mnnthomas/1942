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
     
        //Shoot when primary weapon key is pressed
        public override bool ShootCondition()
        {
            if (Input.GetButton(m_PrimaryWeaponKey))
                return true;

            return false;
        }
    }
}