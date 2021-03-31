using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : NetworkBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private CharacterController controller = null;
    [SerializeField] private Animator animate = null;

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
        enabled = true;

        Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Controls.Player.Move.canceled += ctx => ResetMovement();
    }


    [ClientCallback]
    private void OnEnable() => Controls.Enable();

    [ClientCallback]
    private void OnDisable() => Controls.Disable();

    [ClientCallback] // Needs server authority movement
    private void Update() => Move();

    [Client]
    private void SetMovement(Vector2 movement) => previousInput = movement;

    [Client]
    private void ResetMovement() => previousInput = Vector2.zero;

    [Client]
    private void Move()
    {
        Vector3 right = controller.transform.right;
        Vector3 forward = controller.transform.forward;
        right.y = 0f;
        forward.y = 0f;

        Vector3 movement = right.normalized * previousInput.x + forward.normalized * previousInput.y;
        //Debug.Log(movement);

        
        

        if (Keyboard.current.ctrlKey.wasPressedThisFrame) // if the player is crouching, reduce movement speed
        {
            animate.SetBool("isCrouching", true);
            movementSpeed = 2.5f;
        } else if (Keyboard.current.ctrlKey.wasReleasedThisFrame)
        {
            animate.SetBool("isCrouching", false);
            movementSpeed = 5f;
        }
        controller.Move(movement * movementSpeed * Time.deltaTime);

        // If there is any magnitude at which the player is moving then animate it running
        animate.SetBool("isRunning", movement.magnitude > 0);

       
    }
}
