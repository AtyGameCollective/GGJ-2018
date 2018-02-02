using System.Collections;
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

        [SerializeField] private UnityEvent OnDeplete    = new UnityEvent();
        [SerializeField] private UnityEvent OnComplete   = new UnityEvent();
        [SerializeField] private UnityEvent OnChange     = new UnityEvent();
        [SerializeField] private UnityEvent OnDecomplete = new UnityEvent();

        public float TotalHeat
        {
            get { return _totalHeat; }
            set
            {
                _totalHeat  = value.Clamp(0, value);
                CurrentHeat = CurrentHeat;
            }
        }

        public float CurrentHeat
        {
            get { return _currentHeat; }
            set
            {
                var formerValue = _currentHeat;
                _currentHeat    = value.Clamp(0, _totalHeat);

                if (formerValue != _currentHeat)
                {
                    if (OnChange != null)                                  OnChange.Invoke();
                    if (formerValue == _totalHeat && OnDecomplete != null) OnDecomplete.Invoke();
                }
                if (_currentHeat <= 0            && OnDeplete  != null) OnDeplete.Invoke();
                if (_currentHeat >= _totalHeat   && OnComplete != null) OnComplete.Invoke();
            }
        }

        public float Percent { get { return _currentHeat / _totalHeat; } }

    }
}