using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Arcade1942
{
    /// <summary>
    /// Inits and updates the health bar in player/enemy
    /// </summary>
    public class UIHealth : MonoBehaviour
    {
        [SerializeField] private Slider m_HealthSlider = default;

        public void InitHealthBar(float value)
        {
            if (m_HealthSlider)
            {
                m_HealthSlider.gameObject.SetActive(true);
                m_HealthSlider.maxValue = value;
                m_HealthSlider.value = value;
            }
        }

        public void UpdateHealth(float value)
        {
            m_HealthSlider.value = value;
        }
    }
}
