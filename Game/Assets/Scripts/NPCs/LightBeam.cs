using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATY
{
    public class LightBeam : MonoBehaviour
    {
        [SerializeField] private float    _power = 50;
        [SerializeField] private Animator beamAnimator;

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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Player")) collideWith(collision.collider.GetComponent<PlayerLight>());
            
        }

        private void collideWith(PlayerLight player)
        {
            if (!player) return;
            player.Power += Power;
            myCollider.enabled = false;
        }

        private void triggerFadeAnimation()
        {
            if (beamAnimator) beamAnimator.SetBool("fade",true);
        }

        private void resetFadeAnimation()
        {
            if (beamAnimator) beamAnimator.SetBool("fade", false);
        }

        private void OnEnable()
        {
            resetFadeAnimation();
            myCollider.enabled = true;
        }
    }
}