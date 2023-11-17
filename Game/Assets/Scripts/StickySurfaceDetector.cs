using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StickySurfaceDetector : MonoBehaviour
{
    private PlayerController player;
    private void Awake() {player = this.GetComponentInParent<PlayerController>();}

    private int adjacentStickySurfaces = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StickySurface surface = collision.GetComponent<StickySurface>();
        if (surface != null)
        {
            adjacentStickySurfaces++;
            player.DisableGravity();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StickySurface surface = collision.GetComponent<StickySurface>();
        if (surface != null)
        {
            adjacentStickySurfaces--;
            if (adjacentStickySurfaces < 1) { player.EnableGravity(); }
        }
    }
}
