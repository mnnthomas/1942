﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// Creates the highscore list when highscore button is clicked.
    /// </summary>
    public class UIHighScoreTable : MonoBehaviour
    {
        [SerializeField] private HighScores m_Highscores = default;
        [SerializeField] private GameObject m_HighscoreTemplate = default;
        [SerializeField] private GameObject m_HighscoreList = default;
        [SerializeField] private string m_RankStr = default;
        [SerializeField] private string m_NameStr = default;
        [SerializeField] private string m_ScoreStr = default;

        private void OnEnable()
        {
            if(m_Highscores != null)
            {
                List<HighScoreData> highscoreData = m_Highscores.ReadHighScores();
                if(highscoreData != null && highscoreData.Count > 0)
                {
                    for(int i = 0; i < highscoreData.Count; i++)
                    {
                        GameObject highscore = Instantiate(m_HighscoreTemplate, m_HighscoreList.transform);
                        highscore.transform.Find(m_RankStr).GetComponent<Text>().text = (i+1).ToString();
                        highscore.transform.Find(m_NameStr).GetComponent<Text>().text = highscoreData[i]._Name;
                        highscore.transform.Find(m_ScoreStr).GetComponent<Text>().text = highscoreData[i]._Score.ToString();
                    }
                }
            }
        }

        public void OnClose()
        {
            for (int i = 0; i < m_HighscoreList.transform.childCount; i++)
                Destroy(m_HighscoreList.transform.GetChild(i).gameObject);

            gameObject.SetActive(false);
        }
    }
}
