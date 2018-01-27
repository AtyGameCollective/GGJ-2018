using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aty
{
    /// <summary>
    /// Controls the Light Component properties by subscribing to the HeatTransfer's OnChange Event
    /// </summary>
    [RequireComponent(typeof(HeatTransfer))]
    public class TransferedLight : MonoBehaviour
    {
        [SerializeField] private Light _light = null;
        [ContextMenuItem("Get Light Range", "GetLightRange")]
        [SerializeField] private float initialLightRange = 300;

        [ContextMenuItem("Get Light Spot Angle", "GetLightSpotAngle")]
        [SerializeField] private float initialSpotAngle  = 10;

        private HeatTransfer _heatTransfer = null;
        private HeatTransfer heatTransfer
        {
            get
            {
                if (!_heatTransfer) _heatTransfer = GetComponent<HeatTransfer>();
                return _heatTransfer;
            }
        }

        private void OnEnable()
        {
            if(_light) heatTransfer.AddOnChangeCallback(updateLight);
        }

        private void OnDisable()
        {
            heatTransfer.RemoveOnChangeCallback(updateLight);
        }

        private void updateLight(float value)
        {
            if (_light)
            {
                _light.range     = initialLightRange * value;
                _light.spotAngle = initialSpotAngle  * value;
            }
        }

        private void GetLightRange()
        {
            if (_light) initialLightRange = _light.range;
        }

        private void GetLightSpotAngle()
        {
            if (_light) initialSpotAngle = _light.spotAngle;
        }
    }
}