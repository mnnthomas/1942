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
        [SerializeField] private Image m_BlinkSprite = default;

        private Coroutine healthBlink;

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

        public void Blink(bool value)
        {
            if(value)
            {
                if(healthBlink == null)
                    healthBlink = StartCoroutine(BlinKHealthBar());
            }
            else
            {
                if(healthBlink != null)
                {
                    StopCoroutine(healthBlink);
                    m_BlinkSprite.gameObject.SetActive(true);
                }
            }
        }

        IEnumerator BlinKHealthBar()
        {
            while(true)
            {
                m_BlinkSprite.enabled = !m_BlinkSprite.enabled;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
