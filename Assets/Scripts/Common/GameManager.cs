using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Arcade1942
{
    public class GameManager : MonoBehaviour
    {
        [Header(" -- Object Reference -- ")]
        [SerializeField] private ScoreData m_ScoreData = default;
        [SerializeField] private ObjectSpawner m_Spawner = default;
        [SerializeField] private PlayerMovement m_PlayerMovement = default;
        [SerializeField] private PlayerShoot m_PlayerShoot = default;
        [SerializeField] private UIGameHud m_GameHud = default;
        [Header(" -- Highscore Reference -- ")]
        [SerializeField] private HighScores m_HighScore = default;
        [SerializeField] private TMPro.TMP_InputField m_HighScoreName = default;
        [Header(" -- Scene names -- ")]
        [SerializeField] private string m_RestartScene = default;
        [SerializeField] private string m_MainMenuScene = default;

        public bool pGameRunning { private set; get; }
        public int pPlayerLivesLeft { private set; get; }
        public float pScore { private set; get; }
        public int pEnemyDestroyed { private set; get; }

        private bool mGameStarted = false;
        private bool mPlayerWon = false;

        private void Update()
        {
            if (ObjectPoolManager.pInstance.IsReady() && !pGameRunning && !mGameStarted)
                OnGameStart();
        }

        private void OnEnemyDestroyed(GameObject enemy)
        {
            if (!pGameRunning)
                return;

            pEnemyDestroyed++;
            float value = m_ScoreData.GetScoreForEnemy(enemy);
            pScore += value;

            m_GameHud.UpdateScore(pScore);
        }

        private void OnPlayerDestroyed()
        {
            if (!pGameRunning)
                return;

            pPlayerLivesLeft--;
            m_GameHud.UpdateLives(pPlayerLivesLeft);

            if (pPlayerLivesLeft <= 0)
                OnGameEnd();
        }

        private void OnGameStart()
        {
            mGameStarted = true;
            pGameRunning = true;

            pPlayerLivesLeft = m_ScoreData._PlayerLives;
            m_GameHud.UpdateLives(pPlayerLivesLeft);

            m_PlayerMovement.AllowMovement(true);
            m_PlayerShoot.AllowShoot(true);
            m_Spawner.StartSpawnning();
        }

        private void OnGameEnd()
        {
            pGameRunning = false;
            m_PlayerMovement.AllowMovement(false);
            m_PlayerShoot.AllowShoot(false);
            m_Spawner.StopSpawnning();

            m_GameHud.ShowEndScreen(mPlayerWon);
            if (m_HighScore.IsHighScore(pScore))
                m_GameHud.ShowHighScoreSave(true);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(m_RestartScene);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(m_MainMenuScene);
        }

        public void SaveHighScore()
        {
            if (!string.IsNullOrEmpty(m_HighScoreName.text))
            {
                m_HighScore.AddHighScores(m_HighScoreName.text, pScore);
                m_GameHud.ShowHighScoreSave(false);
            }
        }

    }
}
