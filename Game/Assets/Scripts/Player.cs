using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        Controls controls = new Controls();
        controls.Keyboard.Enable();

        controls.Keyboard.MoveRight.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) => movement=Vector2.right*speed;
        controls.Keyboard.MoveLeft.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) => movement=Vector2.left*speed;
        controls.Keyboard.StopMoving.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) => movement=Vector2.zero;
    }

    [SerializeField] private float speed = 5f;
    private Vector2 movement = Vector2.zero;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity=movement;
    }
}
