using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATY
{
    public class PlayerLight : MonoBehaviour
    {
        [SerializeField] private Light _lightObject          = null;
        [SerializeField] private float _power                = 300f;

        public void Refresh()
        {
            if (_lightObject) _lightObject.range = _power;
        }

        public Light LightObject
        {
            get
            {
                return _lightObject;
            }
            set
            {
                _lightObject = value;
                Refresh();
            }
        }

        public float Power
        {
            get
            {
                return _power;
            }
            set
            {
                _power = value;
                Refresh();
            }
        }

        private void OnEnable()
        {
            Refresh();
        }

        private void OnValidate()
        {
            Refresh();
        }
    }
}