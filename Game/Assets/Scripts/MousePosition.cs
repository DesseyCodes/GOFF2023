using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class MousePosition : MonoBehaviour
{

    Vector3 _mousePos;
    Vector3 _worldPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _mousePos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        //_worldPos = Camera.main.ScreenToWorldPoint(_mousePos);
        transform.position = _mousePos;
    }
}
