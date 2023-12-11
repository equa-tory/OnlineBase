using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    PlayerInput input;

    public Vector2 movementInput;

    public bool i_sprint;
    

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        if (input == null)
        {
            input = new PlayerInput();

            input.Main.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
            
            input.Action.Sprint.performed += ctx => i_sprint = true;
            input.Action.Sprint.canceled += ctx => i_sprint = false;

        }

        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        AllInputs();
    }

    public void AllInputs()
    {

    }


}