using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aty
{
    [RequireComponent(typeof(Light))]
    public class LightController : Heatable
    {

        private Light _myLight = null;
        private Light myLight
        {
            get
            {
                if (!_myLight) _myLight = GetComponent<Light>();
                return _myLight;
            }
        }

        [SerializeField] private float _maxRange     = 300f;
        [SerializeField] private float _minRange     = 0f;
        [SerializeField] private float _maxSpotAngle = 180f;
        [SerializeField] private float _minSpotAngle = 0f;

        public override void OnHeatChange(Heat heat)
        {
            if (!myLight) return;

            myLight.range     = (heat.Percent * _maxRange    ).Clamp(_minRange,     _maxRange);
            myLight.spotAngle = (heat.Percent * _maxSpotAngle).Clamp(_minSpotAngle, _maxSpotAngle);
        }
    }
}