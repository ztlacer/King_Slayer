using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class PlayerAnimationStateController : NetworkBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        //animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        //animator.SetBool("isMoving", gameObject.transform.hasChanged);
    }
}
