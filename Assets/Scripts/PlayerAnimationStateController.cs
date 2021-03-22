using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class PlayerAnimationStateController : NetworkBehaviour
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update

    private bool running = false;

    private Vector2 previousInput;


    private Controls controls;
    private Controls Controls
    {
        get
        {
            if (controls != null) { return controls; }
            return controls = new Controls();
        }
    }
    public override void OnStartAuthority()
    {
        Debug.Log("Start Authority");
        enabled = true;

        Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Controls.Player.Move.canceled += ctx => ResetMovement();
    }


    [ClientCallback]
    private void OnEnable() => Controls.Enable();

    [ClientCallback]
    private void OnDisable() => Controls.Disable();


    [Client]
    private void SetMovement(Vector2 movement) => running = true;

    [Client]
    private void ResetMovement() => running = false;

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            animator.SetBool("isRunning", true);
        }

        if (!running)
        {
            animator.SetBool("isRunning", false);
        }
    }
}
