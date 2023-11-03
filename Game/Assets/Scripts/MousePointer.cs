using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    private void Awake()
    {
        Controls controls = new Controls();
        controls.Mouse.Enable();

        controls.Mouse.Hover.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) => followMouse(context.ReadValue<Vector2>());

        controls.Mouse.EnlargeObject.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) => EnlargeRegistered(context.ReadValue<float>());

        controls.Mouse.ShrinkObject.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) => ShrinkRegistered(context.ReadValue<float>());
    }

    private void followMouse(Vector2 vector)
    {
        vector = Camera.main.ScreenToWorldPoint(vector);
        transform.position = new Vector3(vector.x,vector.y,0f);
    }

    private ScalableObject registered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        registered = collision.GetComponent<ScalableObject>();
        registered?.MouseEntered();
        Debug.Log(registered);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        registered?.MouseExited();
        registered = null;
        Debug.Log(registered);
       
    }

    private void EnlargeRegistered(float value) { registered?.Resize(value); }

    private void ShrinkRegistered(float value) { registered?.Resize(-value); }
    
}
