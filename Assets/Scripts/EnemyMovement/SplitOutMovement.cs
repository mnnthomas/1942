using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class SplitOutMovement : BaseMovement
    {
        [Header(" -- Variables for SplitOut movement ")]
        [SerializeField] private float m_SplitTimer = default;
        [SerializeField] private float m_SplitSpeed = default;

        private float startTime;
        private int turnValue;
        private Vector2 movmentVector;

        private void OnEnable()
        {
            StartMovement();
            turnValue =  Random.Range(0, 100) % 2;
            startTime = Time.time;
        }

        protected override void Move()
        {
            if(Time.time - startTime < m_SplitTimer)
            {
                movmentVector = new Vector2(0, -m_Speed * Time.deltaTime);
                transform.Translate(movmentVector, Space.Self);
            }
            else
            {
                movmentVector = new Vector2(turnValue == 0 ? -m_SplitSpeed : m_SplitSpeed, -m_Speed) * Time.deltaTime;
                transform.Translate(movmentVector, Space.Self);
            }

        }
    }
}

