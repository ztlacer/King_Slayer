//using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

//    private static readonly IDictionary<string, int> mapStates = new Dictionary<string, int>();

    private static Controls controls;
    public static Controls Controls
    {
        get
        {
            if (controls != null) { return controls; }
            return controls = new Controls();
        }
    }

    private void Awake()
    {
        if (controls != null) { return; }
        controls = new Controls();
    }

    private void OnEnable() => Controls.Enable();
    private void OnDisable() => Controls.Disable();
}
