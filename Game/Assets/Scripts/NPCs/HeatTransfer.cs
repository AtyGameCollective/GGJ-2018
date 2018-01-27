using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aty
{
    public class HeatTransfer : MonoBehaviour
    {
        [SerializeField] private float         _power        = 50f;
        [SerializeField] private float         _maxPower     = 50f;
        [SerializeField] private float         _transferRate = 15f;
        [SerializeField] private UnityEvent    _OnComplete   = new UnityEvent();
        [SerializeField] private OnChangeEvent _OnChange     = new OnChangeEvent();
        [SerializeField] private UnityEvent    _OnDeplete    = new UnityEvent();

        private PlayerLight player = null;

        public float Power
        {
            get
            {
                return _power;
            }

            private set
            {
                _power = value.Clamp(0, MaxPower);

                _OnChange.Invoke(_power);
                if (_power <= 0) _OnDeplete.Invoke();
                else if (_power >= MaxPower) _OnComplete.Invoke();
            }
        }

        public float MaxPower
        {
            get
            {
                return _maxPower;
            }

            private set
            {
                _maxPower = value;
            }
        }

        public float TransferRate
        {
            get
            {
                return _transferRate;
            }

            private set
            {
                _transferRate = value;
            }
        }

        public void AddOnCompleteCallback(Action callback)
        {
            _OnComplete.AddListener(callback.Invoke);
        }

        public void RemoveOnCompleteCallback(Action callback)
        {
            _OnComplete.RemoveListener(callback.Invoke);
        }

        public void AddOnDepleteCallback(Action callback)
        {
            _OnDeplete.AddListener(callback.Invoke);
        }

        public void RemoveOnDepleteCallback(Action callback)
        {
            _OnDeplete.RemoveListener(callback.Invoke);
        }

        public void AddOnChangeCallback(Action<float> callback)
        {
            _OnChange.AddListener(callback.Invoke);
        }

        public void RemoveOnChangeCallback(Action<float> callback)
        {
            _OnChange.RemoveListener(callback.Invoke);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) player = other.GetComponent<PlayerLight>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && player)
            {
                player.Power += TransferRate * Time.deltaTime;
                Power -= TransferRate * Time.deltaTime;
            }
        }

        private void OnValidate()
        {
            _power = _power.Clamp(0, _maxPower);
        }

        public class OnChangeEvent : UnityEvent<float> { }
    }
}