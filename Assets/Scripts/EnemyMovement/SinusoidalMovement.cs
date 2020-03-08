using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class SinusoidalMovement : BaseMovement
    {
        [Header(" -- Variable for Sinusoidal movement -- ")]
        [SerializeField] private float m_Amplitude = default;
        [SerializeField] private float m_Period = default;

        private float valueX, valueY;

        private void OnEnable()
        {
            StartMovement();
        }

        protected override void Move()
        {
            valueY = transform.position.y - m_Speed;
            valueX = m_Amplitude * Mathf.Sin(m_Period * valueY);
            transform.position = new Vector3(valueX, valueY, transform.position.z);
        }
    }
}
