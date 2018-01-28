using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aty
{
    public class TriggerScript : MonoBehaviour
    {

        [SerializeField] private GameObject _gate;
        [SerializeField] private int _powerToOpen;

        private Heat player = null;
        private Animator animator;
        private bool inRange = false;
        private bool isOpen = false;

        public GameObject Gate
        {
            get { return _gate; }
            set { _gate = value; }
        }

        public int PowerToOpen
        {
            get { return _powerToOpen; }
            set { _powerToOpen = value; }
        }

        // Use this for initialization
        void Start()
        {
            animator = Gate.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

            if (inRange && !isOpen)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    if (player.CurrentHeat >= PowerToOpen)
                    {
                        player.CurrentHeat -= PowerToOpen;
                        animator.SetTrigger("OpenGate");
                        isOpen = true;
                    }
                }
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                inRange = true;
                player = other.GetComponent<Heat>();
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Tags.Player)) inRange = true;
        }
    }

}