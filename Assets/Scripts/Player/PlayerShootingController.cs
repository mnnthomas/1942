using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// The Player Shooting controller enables the barrels to shoot based on User Inputs.
    /// </summary>
    public class PlayerShootingController : MonoBehaviour
    {
        [Header(" -- Firing values -- ")]
        [SerializeField] private string m_PrimaryWeaponKey = default;
        [SerializeField] private float m_FireRate = default;
        [Header("-- Barrel references --")]
        [SerializeField] private List<BulletBarrel> m_PrimaryBarrels = new List<BulletBarrel>();

        private void Update()
        {
            if (Input.GetButtonUp(m_PrimaryWeaponKey))
            {
                FireBullets();
            }
        }

        private void FireBullets()
        {
            for (int i = 0; i < m_PrimaryBarrels.Count; i++)
                m_PrimaryBarrels[i].Shoot();
        }
    }
}