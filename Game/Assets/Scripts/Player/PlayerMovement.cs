using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Transform playerModel;
    Rigidbody rb;
    float speed = 5f;
    // Use this for initialization
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalMovement = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        this.transform.position += new Vector3(horizontalMovement, 0, verticalMovement);
        if (!Mathf.Approximately(0, verticalMovement) || !Mathf.Approximately(0, horizontalMovement))
        {
            playerModel.localEulerAngles = new Vector3(playerModel.localEulerAngles.x, Mathf.Atan2(-verticalMovement, horizontalMovement) * Mathf.Rad2Deg, playerModel.localEulerAngles.z);
        }
    }
}
