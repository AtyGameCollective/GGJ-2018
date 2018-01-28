using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aty
{
    public class PlayerLight : MonoBehaviour
    {
        /*
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
        */
    }
}