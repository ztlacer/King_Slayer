using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 1f;
    float turnSmoothVelocity;

    private float horizontalX;
    private float horizontalZ;

    private void OnMove(InputValue inputAction)
    {
        Vector2 direction = inputAction.Get<Vector2>();
        horizontalX = direction.x;
        horizontalZ = direction.y;
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = new Vector3(horizontalX, 0f, horizontalZ).normalized;

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
