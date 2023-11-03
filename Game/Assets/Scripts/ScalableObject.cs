using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScalableObject : MonoBehaviour
{
    public void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void MouseEntered()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void MouseExited()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Resize(float value)
    {
        Vector3 oldPosition = transform.position;
        value /= 1800; //divisor open to adjustment. Resizing should feel smooth but not take long
        Vector3 sizeChange = new Vector3(value, value, 0);
        transform.localScale += sizeChange;
        
        transform.Translate(transform.position-oldPosition); //TODO: set position so that object does not fall or get pushed out of wall after resizing
    }
}
