using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SingleAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update

    private void Update()
    {
        animator.SetBool("isRunning", gameObject.transform.hasChanged);
    }
}
