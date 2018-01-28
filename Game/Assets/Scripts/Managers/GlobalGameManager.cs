using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aty
{
    public class GlobalGameManager : MonoBehaviour
    {

        const string MANAGER_PATH = "MANAGER";

        private static GameObject _manager;
        private static Func<GameObject> _Manager = () =>
        {
            _manager = (GameObject)Instantiate(Resources.Load(MANAGER_PATH));
            _manager.name = "Manager";
            _Manager = () => _manager;
            return _manager;
        };

        public static GameObject Manager
        {
            get
            {
                return _Manager();
            }
        }


        private LevelManager _levelManager = null;
        public LevelManager LevelManager
        {
            get
            {
                return _levelManager;
            }
        }

        public void SwitchScene(Scene scene)
        {
            //SceneManager.LoadScene()
        }
    }
}