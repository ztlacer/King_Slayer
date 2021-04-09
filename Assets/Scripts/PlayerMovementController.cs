using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMovementController : NetworkBehaviour
{
    [Range(5f, 10f)]
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private CharacterController controller = null;
    [SerializeField] private Animator animator = null;

    [SerializeField] private CinemachineVirtualCamera cam;

    public float turnSmoothTime = 1f;
    private float turnSmoothVelocity;

    private Vector2 previousInput;

    [Range(.1f, .9f)]
    public float crouchSpeedMultiplier = .5f;

    private float horizontalX = 0;
    private float horizontalZ = 0;

    private Controls controls;
    private Controls Controls
    {
        get
        {
            if (controls != null) { return controls; }
            return controls = new Controls();
        }
    }

    private void Start()
    {
        //animator = gameObject.GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
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

    private void OnMove(InputValue inputAction)
    {
        Vector2 direction = inputAction.Get<Vector2>();
        horizontalX = direction.x;
        horizontalZ = direction.y;

    }

    [Client]
    private void Move()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;

            }
        }
        Vector3 right = controller.transform.right;
        Vector3 forward = controller.transform.forward;
        right.y = 0f;
        forward.y = 0f;

        Vector3 movement = right.normalized * previousInput.x + forward.normalized * previousInput.y;
        //Debug.Log(movement);

        Vector3 direction = new Vector3(horizontalX, 0f, horizontalZ).normalized;

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            float realSpeed = movementSpeed;

            if (Keyboard.current.ctrlKey.wasPressedThisFrame) // if the player is crouching, reduce movement speed
            {
                //animator.SetBool("isCrouching", true);
                realSpeed = movementSpeed * crouchSpeedMultiplier;
            }
            else if (Keyboard.current.ctrlKey.wasReleasedThisFrame)
            {
                //animator.SetBool("isCrouching", false);
                realSpeed = movementSpeed;
            }
            controller.Move(moveDir.normalized * realSpeed * Time.deltaTime);

            // If there is any magnitude at which the player is moving then animate it running
            animator.SetBool("isMoving", movement.magnitude > 0);

            //controller.Move(moveDir.normalized * movementSpeed * Time.deltaTime);

        }

        

       
    }
}
