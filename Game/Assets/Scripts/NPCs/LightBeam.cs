using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aty
{
    public class LightBeam : MonoBehaviour
    {
        [SerializeField] private float    _power       = 50;
        [SerializeField] private float    waitTime     = 1f;
        [SerializeField] private Animator beamAnimator = null;

        private float captureTime = 0;

        private Collider _myCollider = null;
        private Collider myCollider
        {
            get
            {
                if(!_myCollider) _myCollider = GetComponent<Collider>();
                return _myCollider;
            }
        }

        public float Power
        {
            get
            {
                return _power;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) captureTime = Time.time + waitTime;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && Time.time >= captureTime)
            {
                collideWith(other.GetComponent<PlayerLight>());
            }
        }

        private void collideWith(PlayerLight player)
        {
            if (!player) return;
            player.LightTimeRemaining += Power;
            myCollider.enabled = false;
            triggerFadeAnimation();
        }

        private void triggerFadeAnimation()
        {
            if (beamAnimator) beamAnimator.SetBool("Fade",true);
        }

        private void resetFadeAnimation()
        {
            if (beamAnimator) beamAnimator.SetBool("Fade", false);
        }

        private void OnEnable()
        {
            resetFadeAnimation();
            myCollider.enabled = true;
        }
    }
}