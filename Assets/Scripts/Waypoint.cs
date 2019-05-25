using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerToPlace = null;

    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    Vector2Int gridPos;

    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))    //left click
        {
            if (isPlaceable)
            {
                MeshRenderer topMeshRenderer = gameObject.transform.Find("Top").GetComponent<MeshRenderer>();
                Vector3 position = topMeshRenderer.transform.position;
                Instantiate(towerToPlace, position, Quaternion.identity);
                isPlaceable = false;
            }
            else { print("Not placeable"); }
        }
    }
}
