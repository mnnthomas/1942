using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.Arcade1942
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private Button m_BtnPlay;
        [SerializeField] private Button m_BtnHighScore;
        [SerializeField] private Button m_BtnExit;
        [SerializeField] private string m_GameSceneName;
        [SerializeField] private GameObject m_HighScoreTable;

        public void OnPlay()
        {
            SceneManager.LoadScene(m_GameSceneName);
        }

        public void OnShowHighScore()
        {
            m_HighScoreTable.SetActive(true);
        }

        public void OnExit()
        {
            Application.Quit();
        }
    }
}
