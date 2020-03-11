﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.Arcade1942
{
    public class UIGameHud : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_ScoreText = default;
        [SerializeField] private TextMeshProUGUI m_LivesText = default;
        [SerializeField] private GameObject m_SaveHighScore = default;
        [SerializeField] private GameObject m_GameEndScreen = default;
        [SerializeField] private TextMeshProUGUI mGameEndText = default;

        public void UpdateScore(float value)
        {
            m_ScoreText.text = value.ToString();
        }

        public void UpdateLives(float value)
        {
            m_LivesText.text = value.ToString();
        }

        public void ShowEndScreen(bool win, bool highscore)
        {
            m_GameEndScreen.SetActive(true);
          
        }
    }
}
