using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aty
{
    [RequireComponent(typeof(ParticleSystem)), System.Serializable]
    public class HeatParticles : Heatable
    {
        private ParticleSystem _particles;
        private ParticleSystem particles
        {
            get
            {
                if (!_particles) _particles = GetComponent<ParticleSystem>();
                return _particles;
            }
        }

        [SerializeField] private float _maxParticles = 30f;
        [SerializeField] private float _minParticles = 0f;

        public override void OnHeatChange(float value)
        {
            if (!particles) return;

            var emission = particles.emission;
            emission.rateOverTime = (value * _maxParticles).Clamp(_minParticles, _maxParticles);

        }

    }
}