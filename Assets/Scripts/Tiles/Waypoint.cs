using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private Overlay overlay;

    [SerializeField]
    private bool isPlaceable = true;
    public bool IsPlaceable { get { return isPlaceable; } }

    private GameObject placedTower = null;
    private TowersManager towersManager;

    private float gridSnapModifier = 1f;

    private void Start()
    {
        gridSnapModifier = UnityEditor.EditorSnapSettings.scale;

        towersManager = TowersManager.instance;
    }

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

        if(Input.GetMouseButtonDown(0))
        {
            PlaceTower();
        } 
        else if(Input.GetMouseButtonDown(1))
        {
            DestroyTower();
        }
    }

    private void PlaceTower()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.y += gridSnapModifier;

        if (towersManager.selectedTower != null && placedTower == null)
        {
            Instantiate(towersManager.selectedTower, targetPosition, Quaternion.identity, transform);
            placedTower = towersManager.selectedTower;
        }
    }

    private void DestroyTower()
    {
        Debug.Log("Destroy");
        Destroy(placedTower);
        placedTower = null;
    }
}
