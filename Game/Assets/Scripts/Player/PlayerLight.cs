using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aty
{
    public class PlayerLight : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField]
        private float LightTimeTotal = 60f;
        [SerializeField]
        private float lightTimeRemaining;

        private const float MaxPower = 300f;

        [Header("Level Light")]
        [SerializeField]
        private Light _levelLight = null;
        [SerializeField] private float _maxLevelLight = 300f;
        [SerializeField] private float _minLevelLight = 0f;

        [Header("Player Light")]
        [SerializeField]
        private Light _playerLight = null;
        [SerializeField] private float _maxPlayerLight = 10f;
        [SerializeField] private float _minPlayerLight = 0f;

        [Header("Player Particles")]
        [SerializeField]
        private ParticleSystem _playerParticle;
        private ParticleSystem.EmissionModule _playerParticleEmissor;
        [SerializeField] private float _maxPlayerParticles = 30f;
        [SerializeField] private float _minPlayerParticles = 0f;

        [Header("Fog Color")]
        [SerializeField] private Color _maxFogColor = Color.cyan;
        [SerializeField] private Color _minFogColor = Color.black;

        [Header("Events")]

        [SerializeField]
        private UnityEvent OnPowerDeplete = new UnityEvent();

        public Light LevelLightObject
        {
            get
            {
                return _levelLight;
            }
            set
            {
                _levelLight = value;
                Refresh();
            }
        }

        public void LevelLightUpdate(float value)
        {
            _levelLight.range = Mathf.Lerp(_minLevelLight, _maxLevelLight, value);
            _levelLight.spotAngle = Mathf.Lerp(40, 180, value);
        }

        public void PlayerLightUpdate(float value)
        {
            if(_playerLight)
                _playerLight.range = Mathf.Lerp(_minLevelLight, _maxLevelLight, value);
            if(_playerParticle)
                _playerParticleEmissor.rateOverTime = Mathf.Lerp(_minPlayerParticles, _maxPlayerParticles, value );
        }

        public void FogUpdate(float value)
        {
            RenderSettings.fogColor = Color.Lerp(_minFogColor, _maxFogColor, value);
        }

        public float LightTimeRemaining
        {
            get
            {
                return lightTimeRemaining;
            }

            set
            {
                lightTimeRemaining = value;
            }
        }

        public void Refresh()
        {
            float lightValue = Mathf.Lerp(0, 1, LightTimeRemaining / LightTimeTotal);
            
            if (_levelLight)
            {
                LevelLightUpdate(lightValue);
            }
            if (_playerLight)
            {
                PlayerLightUpdate(lightValue);
            }
            FogUpdate(lightValue);

            if(lightValue <= 0 && OnPowerDeplete != null)
            {
                OnPowerDeplete.Invoke();
            }
        }

        private void OnEnable()
        {
            LightTimeRemaining = LightTimeTotal;
            _playerParticleEmissor = _playerParticle.emission;
            Refresh();
        }

        private void Update()
        {
            if (LightTimeRemaining > 0)
            {
                LightTimeRemaining -= Time.deltaTime;
                Refresh();
            }

        }
    }
}