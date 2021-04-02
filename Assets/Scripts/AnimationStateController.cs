using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationStateController : MonoBehaviour
{
    public Animator animator;

    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMove(InputValue inputAction)
    {
        Vector2 direction = inputAction.Get<Vector2>();
        if (direction.magnitude > 0)
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMoving", isMoving);
        if (Keyboard.current.ctrlKey.wasPressedThisFrame)
        {
            animator.SetBool("isSneaking", true);
        }
        else if(Keyboard.current.ctrlKey.wasReleasedThisFrame)
        {
            animator.SetBool("isSneaking", false);
        }
        
    }
}
