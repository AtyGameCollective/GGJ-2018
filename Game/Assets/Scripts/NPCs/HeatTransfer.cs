using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aty
{
    [RequireComponent(typeof(Heat))]
    public class HeatTransfer : MonoBehaviour
    {
        [SerializeField] private float _transferRate = 1f;
        private Heat playerHeat = null;

        private Heat _heat = null;
        private Heat heat
        {
            get
            {
                if (!_heat) _heat = GetComponent<Heat>();
                return _heat;
            }
        }

        public float TransferRate
        {
            get         { return _transferRate; }
            private set { _transferRate = value; }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player.ToString())) playerHeat = other.GetComponent<Heat>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(Tags.Player.ToString()) && playerHeat)
            {
                playerHeat.CurrentHeat += TransferRate * Time.deltaTime;
                heat.CurrentHeat       -= TransferRate * Time.deltaTime;
            }
        }
    }
}