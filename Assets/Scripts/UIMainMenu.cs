using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.Arcade1942
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private string m_GameSceneName = default;
        [SerializeField] private GameObject m_HighScoreTable = default;

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
