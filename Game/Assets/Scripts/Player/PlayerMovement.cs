using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aty
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        Transform playerModel;

        [SerializeField]
        float rotationSpeed = 2f;

        Rigidbody rb;
        float speed = 5f;

        //To use on easing rotation
        float targetAngle = 0f;
        float rotationSize = 0f;
        float rotateDirection = 1f;


        // Use this for initialization
        void Start()
        {
            this.rb = GetComponent<Rigidbody>();
            targetAngle = playerModel.localEulerAngles.y;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float verticalMovement = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
            float horizontalMovement = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

            this.transform.position += new Vector3(horizontalMovement, 0, verticalMovement);

            //Rotate
            float actualAngle = playerModel.localEulerAngles.y;

            if (!Mathf.Approximately(0, verticalMovement) || !Mathf.Approximately(0, horizontalMovement))
            {
                float movementAngle = Mathf.Atan2(-verticalMovement, horizontalMovement) * Mathf.Rad2Deg;

                if (movementAngle < 0) movementAngle = 360 + movementAngle;

                if (!Mathf.Approximately(movementAngle, targetAngle))
                {
                    targetAngle = movementAngle;
                }
            }

            if (!Mathf.Approximately(actualAngle, targetAngle))
            {
                rotateDirection = 1f;

                float angleStep = (targetAngle - actualAngle);

                if (Mathf.Abs(actualAngle - targetAngle) > 180)
                {
                    rotateDirection = -1f;
                    angleStep += (angleStep % 180);
                }

                angleStep = angleStep * rotateDirection * rotationSpeed * Time.deltaTime;
                float YAngle = actualAngle + angleStep;
                
                playerModel.localEulerAngles = new Vector3(playerModel.localEulerAngles.x, YAngle, playerModel.localEulerAngles.z);
                
            }
        }
    }
}
