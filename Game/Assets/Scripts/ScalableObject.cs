using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScalableObject : MonoBehaviour
{
    private void Awake()
    {
        Controls controls = new Controls();
        controls.Mouse.Enable();

        controls.Mouse.Hover.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        {
            CheckIsHoverInThis(context.ReadValue<Vector2>());
        };

        controls.Mouse.Select.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        {
            
        };

        controls.Mouse.Deselect.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        {
            
        };

        controls.Mouse.EnlargeObject.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        {
            
        };

        controls.Mouse.ShrinkObject.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        {
            
        };
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void CheckIsHoverInThis(Vector2 hoverPosition)
    {
        
    }
}
