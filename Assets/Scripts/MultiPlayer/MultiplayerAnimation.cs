using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class MultiplayerAnimation : NetworkBehaviour
{
    public Animator animator;

    bool isMoving = false;

    float elapsedTime = 0;
    // Start is called before the first frame update
    public override void OnStartAuthority()
    {
        enabled = true;
    }

    [ClientCallback] // Needs server authority movement
    private void Update() => Animate();

    private void OnMove(InputValue inputAction)
    {
        print("moved");
        Vector2 direction = inputAction.Get<Vector2>();
        if (direction.magnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }


    private void OnFire(InputValue inputAction)
    {
        print("fire");
        if (elapsedTime == 0)
        {
            animator.SetBool("isAttacking", true);
            elapsedTime += Time.deltaTime;
        }
    }
    // Update is called once per frame
    [Client]
    void Animate()
    {
        animator.SetBool("isMoving", isMoving);
        if (Keyboard.current.ctrlKey.wasPressedThisFrame)
        {
            animator.SetBool("isSneaking", true);
        }
        else if (Keyboard.current.ctrlKey.wasReleasedThisFrame)
        {
            animator.SetBool("isSneaking", false);
        }

        // check elapsed time and stuff.
        if (elapsedTime > 0 && elapsedTime < 1.667) // length of attack anim
        {
            elapsedTime += Time.deltaTime;
        }
        else if (elapsedTime > 1.667)
        {
            print("reset animation");
            elapsedTime = 0;
            animator.SetBool("isAttacking", false);
        }

    }
}
