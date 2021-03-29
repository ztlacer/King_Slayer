using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update

    private bool running = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        if (movementVector.magnitude > 0)
        {
            running = true;
        } else
        {
            running = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            animator.SetBool("isRunning", true);
        } else { 
            animator.SetBool("isRunning", false);
        }

        if (Keyboard.current.ctrlKey.wasPressedThisFrame)
        {
            animator.SetBool("isCrouching", true);
        }
        else if (Keyboard.current.ctrlKey.wasReleasedThisFrame)
        {
            animator.SetBool("isCrouching", false);
        }
    }
}
