using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class DurationAliveStatus : WinCondition
    {
        [SerializeField] private float m_DurationAlive = default;
        [SerializeField] private GameManager m_GameManager = default;

        private float mStartTime;

        public override void Init()
        {
            base.Init();
            mStartTime = Time.time;
        }

        public override void Update()
        {
            base.Update();

            if (m_GameManager.pGameRunning && Time.time - mStartTime >= m_DurationAlive && !pIsReady)
            {
                Debug.Log("Duration Alive == True");
                pIsReady = true;
            }
        }
    }
}