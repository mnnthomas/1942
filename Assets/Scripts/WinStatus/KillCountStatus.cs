using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class KillCountStatus : WinCondition
    {
        [SerializeField] private float m_KillCount = default;
        [SerializeField] private GameManager m_GameManager = default;

        public override void Update()
        {
            base.Update();

            if (m_GameManager.pGameRunning && m_GameManager.pEnemyDestroyed >= m_KillCount && !pIsReady)
            {
                Debug.Log("Kill Count == True");
                pIsReady = true;
            }
        }
    }
}
