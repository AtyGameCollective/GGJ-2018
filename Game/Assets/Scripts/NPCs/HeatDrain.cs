using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aty
{
    [RequireComponent(typeof(Heat))]
    public class HeatDrain : MonoBehaviour
    {

        private Heat _heat = null;
        private Heat heat
        {
            get
            {
                if (!_heat) _heat = GetComponent<Heat>();
                return _heat;
            }
        }

        private void Update()
        {
            if (heat.CurrentHeat > 0) heat.CurrentHeat -= Time.deltaTime;
        }
    }
}