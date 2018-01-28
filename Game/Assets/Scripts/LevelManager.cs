using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Aty
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        bool isPaused = false;

        [SerializeField]
        bool isGameOver = false;

        [SerializeField] GameObject pausePanel;
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] GameObject winPanel;

        private void FixedUpdate()
        {
            if (!isGameOver)
            {
                if (Input.GetButtonDown("Cancel"))
                {
                    if (!isPaused)
                    {
                        Pause();
                    }
                    else
                    {
                        Resume();
                    }
                }
            }
        }

        public void Pause()
        {
            if (!isPaused && pausePanel != null && !isGameOver)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
        }

        public void Resume()
        {
            if (isPaused && !isGameOver)
            {
                CleanStatus();
            }
        }

        public void Restart()
        {
            CleanStatus();

            Application.LoadLevel(Application.loadedLevel);
        }

        public void Win()
        {
            if (!isGameOver)
            {
                Time.timeScale = 0;
                isGameOver = true;
                winPanel.SetActive(true);
            }
        }

        public void Quit()
        {
            CleanStatus();

            GlobalGameManager.GGM.SwitchScene(SceneNames.Menu);
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            isGameOver = true;
            gameOverPanel.SetActive(true);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void CleanStatus()
        {
            pausePanel.SetActive(false);
            winPanel.SetActive(false);
            gameOverPanel.SetActive(false);

            isGameOver = false;
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}