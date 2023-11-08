using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    float gridMultiplier = 0f;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        gridMultiplier = UnityEditor.EditorSnapSettings.move.x;
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            label.enabled = true;
            ShowCoords();
        }
        else
            label.enabled = false;
    }

    private void ShowCoords()
    {
        try
        {
            coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridMultiplier);
            coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridMultiplier);

            label.text = coordinates.ToString();
            transform.parent.name = label.text;
        } 
        catch
        {
            label.text = "--, --";
        }
    }
}
