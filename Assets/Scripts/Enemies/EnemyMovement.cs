using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PlayerManager playerManager;

    [SerializeField]
    private List<Waypoint> path = new List<Waypoint>();

    [SerializeField]
    [Range(0f, 5f)]
    private float speedMultiplier = 1f;

    [SerializeField]
    private int damage = 1;

    private float gridSnapModifier = 1f;

    private void Awake()
    {
        playerManager = PlayerManager.instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        FindPath();

        gridSnapModifier = UnityEditor.EditorSnapSettings.scale;
        StartCoroutine(LoopThroughPath());
    }

    void FindPath()
    {
        path.Clear();
        GameObject waypoints = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in waypoints.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    IEnumerator LoopThroughPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 position = transform.position;
            Vector3 newPosition = waypoint.transform.position;
            newPosition.y += gridSnapModifier;

            float movementMultiplier = 0f;

            transform.LookAt(newPosition);

            while(movementMultiplier <= 1f)
            {
                movementMultiplier += Time.deltaTime * speedMultiplier;
                transform.position = Vector3.Lerp(position, newPosition, movementMultiplier);
                yield return new WaitForEndOfFrame();
            }
        }

        playerManager.SubtractHealthPoints(damage);
        Destroy(gameObject);
    }
}
