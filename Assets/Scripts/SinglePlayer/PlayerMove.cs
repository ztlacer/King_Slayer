using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    [Range(8f, 15f)]
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private CharacterController controller = null;

    private Vector2 previousInput;

    [SerializeField] private Transform cam;

    [Range(.05f, .15f)]
    public float turnSmoothTime = .1f;
    private float turnSmoothVelocity;

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
    void Start()
    {
        enabled = true;

        Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Controls.Player.Move.canceled += ctx => ResetMovement();
    }


    private void OnEnable() => Controls.Enable();

    private void OnDisable() => Controls.Disable();

    private void SetMovement(Vector2 movement) => previousInput = movement;

    private void ResetMovement() => previousInput = Vector2.zero;


    private void OnMove(InputValue inputAction)
    {
        Vector2 direction = inputAction.Get<Vector2>();
        horizontalX = direction.x;
        horizontalZ = direction.y;

        isMoving = horizontalX == 0 && horizontalZ == 0 ? false : true;
    }

    void Update()
    {
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

        if (isMoving)
        { // then calculate movement and stuff.
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            

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
            //print(realSpeed);
            controller.Move(moveDir.normalized * realSpeed * Time.deltaTime);

            //controller.Move(moveDir.normalized * movementSpeed * Time.deltaTime);

        } 

        




    }
}
