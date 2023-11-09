using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private List<Waypoint> path = new List<Waypoint>();

    private float gridSnapModifier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gridSnapModifier = UnityEditor.EditorSnapSettings.scale;
        StartCoroutine(LoopThroughPath());
    }

    IEnumerator LoopThroughPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 newPosition = waypoint.transform.position;
            newPosition.y += gridSnapModifier;
            transform.position = newPosition;
            yield return new WaitForSeconds(1f);
        }
    }
}
