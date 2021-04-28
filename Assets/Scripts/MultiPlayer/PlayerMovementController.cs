using Mirror;
using UnityEngine;
using UnityEngine.EventSystems;
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
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject pauseUI;
    private float elapsedTime = 0f;

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

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
    public override void OnStartAuthority()
    {
        enabled = true;
        freeLook.SetActive(true);
        inventoryUI.SetActive(true);
        GetComponent<PlayerInventory>().enabled = true;
        //cam = GameObject.Find("MainCamera").transform;

        InputManager.Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        InputManager.Controls.Player.Move.canceled += ctx => ResetMovement();
        InputManager.Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        InputManager.Controls.Player.Move.canceled += ctx => ResetMovement();
        InputManager.Controls.Player.Sneak.performed += ctx => SetSneaking();
        InputManager.Controls.Player.Sneak.canceled += ctx => resetSneaking();
        InputManager.Controls.Player.Pause.performed += ctx => PauseGame();
        InputManager.Controls.Player.Fire.performed += ctx => attack();
    }


    //[ClientCallback]
    //private void OnEnable() => Controls.Enable();

    //[ClientCallback]
    //private void OnDisable() => Controls.Disable();

    [ClientCallback] // Needs server authority movement
    private void Update() => Move();

    [Client]
    private void SetMovement(Vector2 movement)
    {
        horizontalX = movement.x;
        horizontalZ = movement.y;
        isMoving = horizontalX == 0 && horizontalZ == 0 ? false : true;
    }
    [Client]
    private void ResetMovement()
    {
        isMoving = false;
        horizontalX = 0;
        horizontalZ = 0;
    }

    [Client]
    private void SetSneaking()
    {
        isSneaking = true;
        animator.SetBool("isSneaking", true);
    }

    [Client]
    private void resetSneaking()
    {
        isSneaking = false;
        animator.SetBool("isSneaking", false);
    }

    [Client]
    public void PauseGame()
    {
        if (InputManager.Controls.Player.enabled)
        {
            InputManager.Controls.Player.Disable();
        }
        else
        {
            InputManager.Controls.Player.Enable();
        }
        pauseUI.SetActive(!pauseUI.activeInHierarchy);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseUI.transform.GetChild(0).gameObject);
    }

    private void attack()
    {
        if (elapsedTime == 0)
        {
            animator.SetBool("isAttacking", true);
            elapsedTime += Time.deltaTime;
        }
    }

    [Client]
    private void Move()
    {
        animator.SetBool("isMoving", isMoving);

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
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (Time.timeScale == 0)
        //    {
        //        Time.timeScale = 1;
        //    } else
        //    {
        //        Time.timeScale = 0;

        //    }
        //}
        Vector3 direction = new Vector3(horizontalX, 0f, horizontalZ).normalized;

        // If there is any magnitude at which the player is moving then animate it running
        //animator.SetBool("isMoving", direction.magnitude > 0);

        //if (Keyboard.current.ctrlKey.wasPressedThisFrame) // if the player is crouching, reduce movement speed
        //{
        //    isSneaking = true;
        //}
        //else if (Keyboard.current.ctrlKey.wasReleasedThisFrame)
        //{
        //    isSneaking = false;
        //}
        // test

        if (isMoving)
        { // then calculate movement and stuff.
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;


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

            Vector3 playerVelocity = moveDir.normalized * realSpeed * Time.deltaTime;
            controller.Move(playerVelocity);



        }


        Vector3 gravityVec = new Vector3();
        if (controller.isGrounded)
        {
            gravityVec.y = 0;

        }
        else
        {
            gravityVec.y += gravity * Time.deltaTime;

        }

        controller.Move(gravityVec);
    }
}
