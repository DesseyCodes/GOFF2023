using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    private Rigidbody2D rigidbody;
    private float verticalMovement = 0;
    private float horizontalMovement = 0;

    private Vector2 MoveWithGravity(Rigidbody2D rigidbody) { return new Vector2(horizontalMovement, rigidbody.velocity.y); }
    private Vector2 MoveWithoutGravity(Rigidbody2D rigidbody) { return new Vector2(horizontalMovement, verticalMovement); }
    private delegate Vector2 Movement(Rigidbody2D rb);
    private Movement movement;
    

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        movement = MoveWithGravity;

        Controls controls = new Controls();
        controls.Keyboard.Enable();

        controls.Keyboard.MoveRight.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        {
            horizontalMovement = speed;
        };
        controls.Keyboard.MoveLeft.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        {
            horizontalMovement = -speed;
        };
        controls.Keyboard.StopMoveHorizontal.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        {
            horizontalMovement = 0;
        };

        controls.Keyboard.MoveUp.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        {
            verticalMovement = speed;
        };
        controls.Keyboard.MoveDown.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        {
            verticalMovement = -speed;
        };
        controls.Keyboard.StopMoveVertical.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        {
            verticalMovement = 0;
        };
    }

    private void FixedUpdate()
    {
        rigidbody.velocity=movement.Invoke(rigidbody);
    }

    public void EnableGravity()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.y, 0);
        movement = MoveWithGravity;
        rigidbody.gravityScale = 1;
    }
    public void DisableGravity()
    {
        movement = MoveWithoutGravity;
        rigidbody.gravityScale = 0;
    }
}