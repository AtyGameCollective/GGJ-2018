using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    public GameObject Gate;
    Animator animator;
    bool inRange = false;

    // Use this for initialization
    void Start () {
        animator = Gate.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
        if(inRange)
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
