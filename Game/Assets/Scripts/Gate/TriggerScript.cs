using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    [SerializeField] private GameObject _gate;
    private Animator animator;
    private bool inRange = false;

    public GameObject Gate
    {
        get { return _gate; }
        set { _gate = value; }
    }

    // Use this for initialization
    void Start()
    {
        animator = Gate.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                animator.SetTrigger("OpenGate");
            }

        }

    }

    void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        inRange = true;
    }
}
