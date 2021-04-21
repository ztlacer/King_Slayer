using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMovementController : NetworkBehaviour
{
    [Range(8f, 15f)]
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float gravity = -10f;
    [SerializeField] private CharacterController controller = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private GameObject freeLook = null;
    [SerializeField] private GameObject playerUI;


    //private Transform cam;

    [Range(.05f, .15f)]
    public float turnSmoothTime = 1f;
    private float turnSmoothVelocity;

    private Vector2 previousInput;

    [Range(.1f, .9f)]
    public float crouchSpeedMultiplier = .5f;

    private float horizontalX = 0;
    private float horizontalZ = 0;

    private bool isMoving = false;

    private bool isSneaking = false;

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
        controller = gameObject.GetComponent<CharacterController>();
    }
    public override void OnStartAuthority()
    {
        enabled = true;
        freeLook.SetActive(true);
        playerUI.SetActive(true);
        GetComponent<PlayerInventory>().enabled = true;
        //cam = GameObject.Find("MainCamera").transform;

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

        isMoving = horizontalX == 0 && horizontalZ == 0 ? false : true;
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
        // New Code for networked movement
        Vector3 direction = new Vector3(horizontalX, 0f, horizontalZ).normalized;

        // If there is any magnitude at which the player is moving then animate it running
        //animator.SetBool("isMoving", direction.magnitude > 0);

        if (Keyboard.current.ctrlKey.wasPressedThisFrame) // if the player is crouching, reduce movement speed
        {
            isSneaking = true;
        }
        else if (Keyboard.current.ctrlKey.wasReleasedThisFrame)
        {
            isSneaking = false;
        }
        // test

        if (isMoving)
        { // then calculate movement and stuff.
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y; // Here Camera.main refers to the primary camera with the tag "MainCamera"


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            float realSpeed = movementSpeed;
            float realTurnTime = turnSmoothTime;


            if (isSneaking)
            {
                print("holding");
                realSpeed = movementSpeed * crouchSpeedMultiplier; // make their character turn slower too
                realTurnTime = 4 * turnSmoothTime;
            }

            //else if (Keyboard.current.ctrlKey.wasReleasedThisFrame)
            //{
            //animator.SetBool("isSneaking", false);
            //print("player stopped crouching");
            //realSpeed = movementSpeed;
            //realTurnTime = turnSmoothTime;
            //}

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, realTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 playerVelocity = moveDir.normalized * movementSpeed * Time.deltaTime;
            if (controller.isGrounded)
            {
                playerVelocity.y = 0;

            }
            else
            {
                playerVelocity.y += gravity * Time.deltaTime;

            }
            controller.Move(playerVelocity);

        }
    }
}
