﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aty
{
    public class Heat : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float _totalHeat = 60f;
        [SerializeField] private float _currentHeat = 0f;

        [Header("Events")]

        [SerializeField] private UnityEvent      OnDeplete  = new UnityEvent();
        [SerializeField] private UnityEvent      OnComplete = new UnityEvent();
        [SerializeField] private List<Heatable> _OnChange   = new List<Heatable>();

        private void OnChange(float percent)
        {
            foreach (var element in _OnChange)
            {
                if (element) element.OnHeatChange(percent);
                else _OnChange.Remove(element);
            }
        }

        public float TotalHeat
        {
            get { return _totalHeat; }
            set
            {
                _totalHeat = value.Clamp(0, value);
                CurrentHeat = CurrentHeat;
            }
        }

        public float CurrentHeat
        {
            get { return _currentHeat; }
            set
            {
                _currentHeat = value.Clamp(0, _totalHeat);

                OnChange(HeatPercent);
                if (_currentHeat <= 0          && OnDeplete  != null) OnDeplete.Invoke();
                if (_currentHeat >= _totalHeat && OnComplete != null) OnComplete.Invoke();
            }
        }

        public float HeatPercent { get { return _currentHeat / _totalHeat; } }

        private void OnEnable()
        {
            OnChange(HeatPercent);

        }

        [System.Serializable] public class UnityEventFloat : UnityEvent<float> { }
    }
}