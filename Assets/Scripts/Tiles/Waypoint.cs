using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private Overlay overlay;

    [SerializeField]
    private bool isPlaceable = true;

    private void OnMouseOver()
    {
        if (!isPlaceable) return;
            
        overlay.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (!isPlaceable) return;

        overlay.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!isPlaceable) return;

        Debug.Log(transform.name);
    }
}
