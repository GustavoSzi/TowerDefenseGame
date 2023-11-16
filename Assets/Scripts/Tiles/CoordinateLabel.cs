using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    private TextMeshPro label;
    private Waypoint waypoint;
    private Vector2Int coordinates = new Vector2Int();

    float gridMultiplier = 0f;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        gridMultiplier = UnityEditor.EditorSnapSettings.move.x;
    }

    private void Update()
    {
        if (PrefabStageUtility.GetCurrentPrefabStage() == null)
        {
            ShowCoords();
        }

        CheckColor();
        ToggleVisibility();
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

    private void CheckColor()
    {
        if (!waypoint.IsPlaceable)
            label.color = Color.gray;
        else
            label.color = Color.white;
    }

    private void ToggleVisibility()
    {
        if (Input.GetKeyDown(KeyCode.C))
            label.enabled = !label.IsActive();
    }
}
