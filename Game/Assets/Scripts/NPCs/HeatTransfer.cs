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

        private PlayerMovement _playerMove = null;
        private PlayerMovement playerMove
        {
            get
            {
                if (!_playerMove && playerHeat)
                {
                    _playerMove = playerHeat.GetComponent<PlayerMovement>();
                }
                return _playerMove;
            }
        }

        public float TransferRate
        {
            get         { return _transferRate; }
            private set { _transferRate = value; }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player)) playerHeat = other.GetComponent<Heat>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(Tags.Player) && playerHeat)
            {
                if (_transferRate < 0 && !playerMove.IsGiving) return;
                playerHeat.CurrentHeat += TransferRate * Time.deltaTime;
                heat.CurrentHeat       -= TransferRate * Time.deltaTime;
            }
        }
    }
}