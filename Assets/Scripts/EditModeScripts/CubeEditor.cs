using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [Tooltip("The size of each grid space an object will snap to.")]
    [Range(1, 20)]
    [SerializeField] int gridSize = 10;

    TextMesh textMesh;

    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0, snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
