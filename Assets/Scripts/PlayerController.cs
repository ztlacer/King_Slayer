using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        if (!isLocalPlayer)
        {
            return;
        }
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        //rb.AddForce(movement);

        rb.transform.Translate(movement);

    }
}
