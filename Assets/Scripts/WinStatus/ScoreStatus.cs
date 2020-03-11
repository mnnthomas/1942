using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class ScoreStatus : WinCondition
    {
        [SerializeField] private float m_ScoreToCheck = default;
        [SerializeField] private GameManager m_GameManager = default;

        public override void Update()
        {
            base.Update();

            if(m_GameManager.pGameRunning && m_GameManager.pScore >= m_ScoreToCheck && !pIsReady)
            {
                Debug.Log("Score == True");
                pIsReady = true;
            }
        }
    }
}

