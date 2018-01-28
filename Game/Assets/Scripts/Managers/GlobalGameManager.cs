using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

namespace Aty
{
    public class GlobalGameManager : MonoBehaviour
    {
        [SerializeField] private Image transitionImage = null;

        const string MANAGER_PATH = "MANAGER";

        private static GameObject _manager;
        private static Func<GameObject> _Manager = () =>
        {
            _manager = (GameObject)Instantiate(Resources.Load(MANAGER_PATH));
            _manager.name = "Manager";
            DontDestroyOnLoad(_manager);
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

        private static GlobalGameManager _GGM;
        public static GlobalGameManager GGM
        {
            get
            {
                if (!_GGM) _GGM = Manager.GetComponent<GlobalGameManager>();
                return _GGM;
            }
        }

        private LevelManager _levelManager = null;
        public LevelManager LevelManager
        {
            get
            {
                if(!_levelManager) _levelManager = FindObjectOfType<LevelManager>();
                return _levelManager;
            }
        }

        public void SwitchScene(string sceneName)
        {
            if (transitionImage)
            {
                transitionImage.color = Color.clear;
                transitionImage.enabled = true;
                transitionImage.DOFade(1, 1).OnComplete(() => LoadScene(sceneName));
            }
            else
            {
                LoadScene(sceneName);
            }
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);

            if (transitionImage)
            {
                transitionImage.color = Color.black;
                transitionImage.enabled = true;
                transitionImage.DOFade(0, 1).OnComplete(() => transitionImage.enabled = false);
            }
        }
    }
}