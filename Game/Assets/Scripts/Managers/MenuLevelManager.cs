using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aty
{
    public class MenuLevelManager :  LevelManager
    {
        [SerializeField] GameObject creditsPanel;
        public void LoadFirstLevel()
        {
            GlobalGameManager.GGM.SwitchScene(SceneNames.Labrinth);
        }

        public void OpenCreditsScreen()
        {
            Debug.Log("credits");
            creditsPanel.SetActive(true);
        }

        public void QuitGame()
        {
            Debug.Log("quit");
            Application.Quit();
        }
    }
}