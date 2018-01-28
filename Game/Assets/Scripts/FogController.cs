using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aty
{
    [System.Serializable]
    public class FogController : Heatable
    {
        [Header("Fog Color")]
        [SerializeField] private Gradient fogGradient = new Gradient();

        public override void OnHeatChange(float value)
        {
            RenderSettings.fogColor = fogGradient.Evaluate(value);
        }
    }
}