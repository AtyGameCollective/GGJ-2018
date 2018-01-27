using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ATY
{
    public class PlayerLight : MonoBehaviour
    {
        private const float MaxPower = 300f;

        [Header("Properties")]

        [SerializeField] private Light      _lightObject   = null;
        [SerializeField] private float      _power         = 300f;
        [SerializeField] private float      _decreaseRate  = 10f;

        [Header("Events")]

        [SerializeField] private UnityEvent OnPowerDeplete = new UnityEvent();

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
                _power = value.Clamp(0, MaxPower);
                Refresh();
                if (_power <= 0 && OnPowerDeplete != null) OnPowerDeplete.Invoke();
            }
        }

        public void Refresh()
        {
            if (_lightObject)
            {
                _lightObject.range = _power;
                _lightObject.spotAngle = 180f * _power / MaxPower;
            }
        }

        private void PowerDecrement()
        {
            if (Power > 0) Power -= _decreaseRate * Time.deltaTime;
        }

        private void OnEnable()
        {
            Refresh();
        }

        private void Update()
        {
            PowerDecrement();
        }

        private void OnValidate()
        {
            Refresh();
        }
    }
}